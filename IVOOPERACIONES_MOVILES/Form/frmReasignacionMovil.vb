Public Class frmReasignacionMovil
    Dim coll_Responsables As New Collection
    Dim idpersona_recojo As Integer = 0
    Public v_idSolicitudEntrega As String
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmReasignacionMovil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmReasignacionMovil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim lds_tmp As New DataSet
            '
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            'rst = ObjFiltrosEntregaRecojos.fnSP_BUSCAR_DATOS_SILICITUD(v_idSolicitudEntrega)
            lds_tmp = ObjFiltrosEntregaRecojos.fnSP_BUSCAR_DATOS_SILICITUD(v_idSolicitudEntrega)
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                txtCliente.Text = lds_tmp.Tables(0).Rows(0).Item("razon_social")
                txtDireccion.Text = lds_tmp.Tables(0).Rows(0).Item("direccion")
                txtfechahora.Text = lds_tmp.Tables(0).Rows(0).Item("Fecha_Hora")
                idpersona_recojo = lds_tmp.Tables(0).Rows(0).Item("idpersona_recojo")
            End If
            'If rst.EOF = False And rst.BOF = False Then
            'txtCliente.Text = rst.Fields.Item("razon_social").Value
            'txtDireccion.Text = rst.Fields.Item("direccion").Value
            'txtfechahora.Text = rst.Fields.Item("Fecha_Hora").Value
            'idpersona_recojo = rst.Fields.Item("idpersona_recojo").Value
            'End If
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(1), cmbResponsableMovil, coll_Responsables, idpersona_recojo)
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            Dim idNuevoresponsable As Integer = Int(coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString()))
            If idNuevoresponsable >= 0 Then
                ObjFiltrosEntregaRecojos.fnSP_REASIGNAR_RESPONSABLE(v_idSolicitudEntrega, idNuevoresponsable)
                Close()
            Else
                MsgBox("Debe seleccionar un responsable de móvil....", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class