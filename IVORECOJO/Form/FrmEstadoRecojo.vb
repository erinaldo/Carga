Public Class FrmEstadoRecojo
    Public iNum As Integer
    Public iEstado As Integer
    Dim bSalir As Boolean = True

    Private Sub FrmEstado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TxtObservacion.Focus()
    End Sub

    Private Sub FrmEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FrmEstado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As String
        Dim sEstado As String = ""

        s = "Ha Seleccionado " & iNum & " " & IIf(iNum = 1, "Recojo.", "Recojos.")
        s &= vbCrLf & vbCrLf
        s &= "¿Está Seguro de " & NombreEstado(iEstado, iNum) & "?"

        Me.LblMensaje.Text = s

    End Sub

    Function NombreEstado(ByVal estado As Integer, ByVal numero As Integer) As String
        Dim s As String = ""
        Select Case estado
            Case 2
                If numero = 1 Then
                    s = "Aprobarlo"
                Else
                    s = "Aprobarlos"
                End If
            Case 6
                If numero = 1 Then
                    s = "Cancelarlo"
                Else
                    s = "Cancelarlos"
                End If
            Case Else
                If numero = 1 Then
                    s = "Actualizarlo"
                Else
                    s = "Actualizarlos"
                End If
        End Select
        Return s
    End Function

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        bSalir = True
        If iEstado = Recojo.CANCELADO Then
            If Me.TxtObservacion.Text.Trim.Length = 0 Then
                bSalir = False
                MessageBox.Show("Ingrese la Observación.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtObservacion.Text = Me.TxtObservacion.Text.Trim
                Me.TxtObservacion.Focus()
            End If
        End If
    End Sub

    Private Sub BtnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        bSalir = True
    End Sub

    Private Sub TxtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObservacion.Enter
        Me.TxtObservacion.SelectAll()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bSalir = True
        Close()
    End Sub
End Class