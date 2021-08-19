'Imports System.Windows.Forms
'Imports System.Drawing

Public Class FormPadre

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'MyBase.OnPaint(e)
        'Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        'Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRegion(gradiente, New Region(rec))

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Info, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FormPadre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SplitContainer1.Panel1Collapsed = True
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SplitContainer1.Panel1Collapsed = False
    End Sub


End Class