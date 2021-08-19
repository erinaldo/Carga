Public Class frmVerHuella
    Public imagen As Image

    Private Sub frmVerHuella_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        picHuella.Image = imagen
    End Sub

    Private Sub frmVerHuella_ResizeBegin(sender As Object, e As System.EventArgs) Handles Me.ResizeBegin
        Me.Text = "Huella - Haciendo Zoom..."
    End Sub

    Private Sub frmVerHuella_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
        Me.Text = "Huella"
    End Sub

    Private Sub frmVerHuella_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        picHuella.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
End Class