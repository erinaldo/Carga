Public Class frmAcercaDe

    Private Sub frmAcercaDe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblDetalle.Text = "Sistema de Gestión de Carga - Titán" & vbCrLf & ModuUtil.V_VERSION
        lblDetalle.Text = lblDetalle.Text & vbCrLf & "Desarrollado por el Area de Sistemas © 2012"
        lblDetalle.Text = lblDetalle.Text & vbCrLf & "JOTASYS"
        lblDetalle.Text = lblDetalle.Text & vbCrLf & vbCrLf & "Titán es un sistema de centralización de datos de las operaciones"
        lblDetalle.Text = lblDetalle.Text & vbCrLf & " de la empresa."
        lblDetalle.Text = lblDetalle.Text & vbCrLf & vbCrLf & "Las interfaces y funcionalidades del sistema estan protegidas y es"
        lblDetalle.Text = lblDetalle.Text & vbCrLf & "propiedad intelectual de JOTASYS."
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub
End Class