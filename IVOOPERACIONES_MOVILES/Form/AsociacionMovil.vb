Public Class FrmAsociacionMovil
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_idtipoOPeracion = ObjFiltrosEntregaRecojos.coll_Tipo_OPeracion.Item(cmbTipoOperacion.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_Atendido = ObjFiltrosEntregaRecojos.coll_Atendido.Item(cmbAtendido.SelectedIndex.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmAsociacionMovil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub AsociacionMovil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtFecha_Operacion.Text = dtoUSUARIOS.m_sFecha
            If ObjFiltrosEntregaRecojos.fnLISTA_SINO_TIPO_MOVIL() = False Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                'rst = ObjFiltrosEntregaRecojos.CUR_DATOS
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(0), cmbResponsableMovil, ObjFiltrosEntregaRecojos.coll_Responsables, 0)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(1), cmbAtendido, ObjFiltrosEntregaRecojos.coll_Atendido, 0)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(2), cmbTipoOperacion, ObjFiltrosEntregaRecojos.coll_Tipo_OPeracion, 0)
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub cmbResponsableMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbResponsableMovil.SelectedIndexChanged
        Try
            Dim idResponsable As Integer
            idResponsable = Int(cmbResponsableMovil.SelectedIndex)
            If idResponsable >= 0 Then
                idResponsable = IIf(cmbResponsableMovil.SelectedIndex.ToString() <> "", Int(ObjFiltrosEntregaRecojos.coll_Responsables(cmbResponsableMovil.SelectedIndex.ToString())), 0)
                If ObjFiltrosEntregaRecojos.fnLISTA_CODIGO_MOVIL(idResponsable) = False Then
                    'txtCodigoCelular.Text = ObjFiltrosEntregaRecojos.CUR_DATOS.Fields.Item("CODIGO").Value
                    txtCodigoCelular.Text = ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(0).Rows(0).Item("CODIGO").Value
                Else
                    txtCodigoCelular.Text = "NO ASOCIADO..."
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        Catch ex As Exception

        End Try
    End Sub

End Class