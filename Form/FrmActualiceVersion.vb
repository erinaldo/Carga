Public Class FrmActualiceVersion

    Private Sub BtnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcep.Click
        Try
            'System.Diagnostics.Process.Start("http://www.tepsa.com.pe/descargas/")
            End
        Catch ex As Exception
            End
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label1.ForeColor = Color.Transparent Then
            Label1.ForeColor = Color.Red
        Else
            Label1.ForeColor = Color.Transparent
        End If
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub FrmActualiceVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label13.Text = V_VERSION
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click, Label4.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label12.Click, Label11.Click, Label10.Click
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            'System.Diagnostics.Process.Start("http://www.tepsa.com.pe/CargoDescargas/")
            System.Diagnostics.Process.Start("http://www.tepsa.com.pe/CargoDescargas/")

            End
        Catch ex As Exception
            End
        End Try
    End Sub

    Private Sub FrmActualiceVersion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class