Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class FrmMantenimientoGesionDxLT

    Private lobj_FrmBuscEntidades As Frm_BuscarCliente

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        F_Save()
    End Sub

    Private Function F_Save() As Integer

        'Dim ObjInsMantGestionDXLT_LN As New Cls_InsMantGestionDXLT_LN
        Dim ObjInsMantGestionDXLT_EN As New Cls_InsMantGestionDXLT_ENvb

        MsgBox("Se grabo con exito")
        Close()


    End Function

    Private Sub FrmMantenimientoGesionDxLT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtFechaCreacion.Text = Format(Now, "dd-MM-yyyy")
        TxtUsuario.Text = gStr_CodUsuario
        Me.TxtCliente.Focus()

    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown

        Dim lInt_ResultFrm As Integer

        Select Case e.KeyData
            Case Keys.F3

                lobj_FrmBuscEntidades = New Frm_BuscarCliente
                ' lInt_ResultFrm = lobj_FrmBuscEntidades.ShowDialog(lStr_TipoTabla) 'aqui
                lInt_ResultFrm = lobj_FrmBuscEntidades.ShowDialog()
                If lInt_ResultFrm = Windows.Forms.DialogResult.OK Then
                    If Not IsDBNull(lobj_FrmBuscEntidades.DgvBuscador.DataSource) Then
                        If lobj_FrmBuscEntidades.DgvBuscador.Rows.Count > 0 Then
                            Try
                                TxtCliente.Text = lobj_FrmBuscEntidades.DgvBuscador.Item(1, lobj_FrmBuscEntidades.DgvBuscador.CurrentRow.Index).Value
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        End If
                    End If
                End If
        End Select
    End Sub
End Class