Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        For Each scrn As Screen In Screen.AllScreens
            lstMonitor.Items.Add(scrn.ToString)
            lstMonitor.Items.Add(Screen.AllScreens.Length)
        Next
    End Sub
End Class