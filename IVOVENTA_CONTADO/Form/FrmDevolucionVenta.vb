Public Class FrmDevolucionVenta
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            MsgBox("Esta Seguro de realizar esta OPeracion...", MsgBoxStyle.Information, "Seguridad Sistema")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
End Class