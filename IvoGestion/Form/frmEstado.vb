Public Class frmEstado
    Public Lista As New ArrayList
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Public Sub Agrega(ByVal estado As Integer)
        Lista.Add(estado)
    End Sub

    Private Sub frmEstado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmEstado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With dgvEstado
                .AllowUserToAddRows = False
                .Rows.Add(7)
                .Rows(0).Cells(1).Value = "REGISTRO"
                .Rows(1).Cells(1).Value = "DESPACHO"
                .Rows(2).Cells(1).Value = "DESPACHO PARCIAL"
                .Rows(3).Cells(1).Value = "RECEPCION"
                .Rows(4).Cells(1).Value = "RECEPCION PARCIAL"
                .Rows(5).Cells(1).Value = "REPARTO"
                .Rows(6).Cells(1).Value = "ENTREGA"

                .Rows(0).Cells(2).Value = "18"
                .Rows(1).Cells(2).Value = "19"
                .Rows(2).Cells(2).Value = "41"
                .Rows(3).Cells(2).Value = "20"
                .Rows(4).Cells(2).Value = "40"
                .Rows(5).Cells(2).Value = "47"
                .Rows(6).Cells(2).Value = "21"

                .Columns(0).Width = 50
                .Columns(1).Width = 200

                If Not IsNothing(Lista) Then
                    CargarEstados()
                End If
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim bExito As Boolean = False

        Lista.Clear()
        For Each row As DataGridViewRow In dgvEstado.Rows
            If Convert.ToBoolean(row.Cells(0).Value) Then
                Agrega(row.Cells(2).Value)
                bExito = True
            End If
        Next

        If bExito Then
            FrmConsultaGeneral2.aLista = Lista
            Me.Close()
        Else
            MessageBox.Show("Debe Seleccionar al menos un Estado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CargarEstados()
        Dim i As Integer
        Dim j As Integer


        For i = 0 To Lista.Count - 1
            With dgvEstado
                For j = 0 To .Rows.Count - 1
                    If .Rows(j).Cells(2).Value = Lista(i) Then
                        .Rows(j).Cells(0).Value = True
                        Exit For
                    End If
                Next
            End With
        Next
    End Sub
End Class