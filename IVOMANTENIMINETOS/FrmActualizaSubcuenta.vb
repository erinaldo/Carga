Public Class FrmActualizaSubcuenta
    Dim blnSalir As Boolean

    Private Sub FrmActualizaSubcuenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then e.Cancel = True
    End Sub

    Private Sub FrmActualizaSubcuenta_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ServiceLocator.getUtilData.cargarCombos("t_unidadAgencia", cmbCiudad, True, cmbCiudad.DataSource)

        cmbCiudad_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCiudad.SelectedIndexChanged
        If IsReference(Me.cmbCiudad.SelectedValue) Then Return
        ServiceLocator.getUtilData.cargarCombos("t_subcuenta", cmbSubcuenta, False, , Me.cmbCiudad.SelectedValue)
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cmbSubcuenta.SelectedValue = -1 Then
            MessageBox.Show("Seleccione Nueva Subcuenta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbSubcuenta.Focus()
            Me.cmbSubcuenta.DroppedDown = True
            blnSalir = False
            Return
        End If

        If MessageBox.Show("¿Está seguro de actualizar?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.btnAceptar.Focus()
            blnSalir = False
            Return
        End If

        blnSalir = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
    End Sub
End Class