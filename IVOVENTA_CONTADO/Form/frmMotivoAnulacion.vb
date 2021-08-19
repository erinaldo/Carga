Public Class frmMotivoAnulacion
    Dim blnSalir As Boolean

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtMotivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Motivo de la Anulación", "Motivo de Anulación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Text = Me.txtMotivo.Text.Trim
            Me.txtMotivo.Focus()
            blnSalir = False
        End If

        If Me.txtMotivo.Text.Trim.Length < 5 Then
            MessageBox.Show("El Motivo de la Anulación debe ser mayor a 5 caracteres", "Motivo de Anulación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Text = Me.txtMotivo.Text.Trim
            Me.txtMotivo.Focus()
            blnSalir = False
        End If

        Dim chCar As Char = Me.txtMotivo.Text.Substring(0)
        Dim intCar As Integer = Asc(chCar)
        If Not ((intCar >= 97 And intCar <= 122) Or (intCar >= 65 And intCar <= 90)) Then
            MessageBox.Show("El 1er Caracter debe ser un caracter válido (A..Z a..z)", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Focus()
            blnSalir = False
        End If

    End Sub

    Private Sub frmMotivoAnulacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMotivoAnulacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnSalir = True
    End Sub

    Private Sub txtMotivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtMotivo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub
End Class