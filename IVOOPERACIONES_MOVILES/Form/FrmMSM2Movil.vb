Public Class FrmMSM2Movil
    Dim col_Responsable As New Collection
    Public idusuario As Integer = 999
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmMSM2Movil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmMSM2Movil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ModuUtil.LlenarComboIDs_dt(ObjEntregaCarga.fnLISTAR_RESPONSABLES_MOVIL(), cmbResponsableMovil, col_Responsable, idusuario)
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbResponsableMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbResponsableMovil.SelectedIndexChanged
        Try
            idusuario = col_Responsable.Item(cmbResponsableMovil.SelectedIndex.ToString())
            txtNroFono.Text = ObjEntregaCarga.fnBuscarNroMovil(idusuario)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub btnSENDMSM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSENDMSM2.Click
        Try
            Dim strMovil As String = txtNroFono.Text
            Dim strNroMovil As String() = Split(txtNroFono.Text, "*")
            If strNroMovil.Length > 1 Then
                strMovil = strNroMovil(0) & strNroMovil(1)
            Else
                strMovil = txtNroFono.Text
            End If
            ObjEntregaCarga.fnSP_ENVIO_MSM2(1, strMovil, txtMensaje.Text)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
End Class