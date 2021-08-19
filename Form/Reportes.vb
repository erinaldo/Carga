Imports System.Windows.Forms
Imports System.Drawing
Public Class Reportes

    Private Sub Zoom_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Zoom.Scroll
        Me.Label1.Text = Me.Zoom.Value.ToString
        Me.pd.Zoom = Zoom.Value / 100
    End Sub

    Private Sub Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Zoom.Value = 74
        Me.pd.Zoom = Zoom.Value / 100
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(pd.Zoom.ToString)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ClientSize())
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
End Class