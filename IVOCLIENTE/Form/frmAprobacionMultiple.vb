Public Class frmAprobacionMultiple
    Dim blnSalir As Boolean = True

    Private Sub dtpFechaActivacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaActivacion.ValueChanged
        Me.lblFechaActivacion.Text = dtpFechaActivacion.Value.ToShortDateString
    End Sub

    Private Sub frmAprobacionMultiple_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAprobacionMultiple_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.dtpFechaActivacion.Value = DateAdd("d", 1, Now).ToString("dd/MM/yyyy")
        lblFechaActivacion.Text = Me.dtpFechaActivacion.Value.ToShortDateString
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de Aprobar las solicitudes seleccionadas?", "Aprobar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            blnSalir = False
        End If
    End Sub
End Class