Public Class FrmReasignacionGuiasEnvio

    Private Sub FrmReasignacionGuiasEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShadowLabel1.Text = "Reasignación de Guias de Envio"
        Me.MenuTab.Items(0).Text = "REASIGNACION"
        HabilitarMenu(MenuTab)
    End Sub
End Class
