Imports System.Windows.Forms
Imports System.Drawing
Public Class frmBaseVentas
    Private Sub frmBaseVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub TabDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabDatos.Paint, TabLista.Paint, TabPage1.Paint, TabPage2.Paint, TabPage3.Paint, TabPage4.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        SelectMenu(0)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        SelectMenu(1)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        SelectMenu(2)
    End Sub
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        SelectMenu(3)
    End Sub
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        SelectMenu(4)
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        SelectMenu(5)
    End Sub

    Private Sub MenuTab_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuTab.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Public Sub SelectMenu(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
        TabMante.SelectedIndex = ItemMenu
    End Sub
    Public Sub SelectMenu2(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
    End Sub
End Class