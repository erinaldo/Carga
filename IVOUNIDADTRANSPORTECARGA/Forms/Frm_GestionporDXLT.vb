Public Class Frm_GestionporDXLT

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TlbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlbNuevo.Click
        Dim lobj_FrmMantenimientoGesionDxLT As New FrmMantenimientoGesionDxLT
        Dim lStr_BuscarCodigoDivision As String = ""
        Try
            lobj_FrmMantenimientoGesionDxLT.TextOperacion.Text = "NEW"
            lobj_FrmMantenimientoGesionDxLT.Text = "Nuevo registro"
            lobj_FrmMantenimientoGesionDxLT.ShowDialog()
            'F_Retrieve()
            'lStr_BuscarCodigoDivision = lobj_FrmMantenimientoGesionDxLT.cboDivision.SelectedValue
            Dim lObj_ClsUtilitarios As New Cls_Utilitarios
            lObj_ClsUtilitarios.F_Buscar(lStr_BuscarCodigoDivision, "cod_division", DgvGestionDXLT)
        Catch ex As Exception
            MsgBox(Err.Description)
            lobj_FrmMantenimientoGesionDxLT = Nothing
        End Try
    End Sub
    
End Class