Public Class frmRangoGuiasRemision
    Public Serie As String
    Public Inicio As String
    Public Final As String
    Public AGREGA As Integer = 0
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinal.KeyPress, txtInicio.KeyPress, txtSerie.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Serie = IIf(txtSerie.Text <> "", txtSerie.Text, "-1")
            Inicio = IIf(txtInicio.Text <> "", txtInicio.Text, "-1")
            Final = IIf(txtFinal.Text <> "", txtFinal.Text, "-1")
            AGREGA = Int(Me.checkSINO.Checked)
            If Int(Final) > Int(Inicio) And Int(Serie) >= 0 And Int(Final) - Int(Inicio) < 100 And Int(Final) - Int(Inicio) > 0 Then
                Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("No puede realizar esta Operacion debe tener una serie mayor a cero y el valor Final debe ser mayor a valor inicial...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub frmRangoGuiasRemision_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmRangoGuiasRemision_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmRangoGuiasRemision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class