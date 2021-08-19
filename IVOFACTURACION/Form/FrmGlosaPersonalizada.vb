Public Class FrmGlosaPersonalizada
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'MyBase.OnPaint(e)
        'Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        'Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmGlosaPersonalizada_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmGlosaPersonalizada_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmGlosaPersonalizada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcep.Click
        Me.RTB.Text = RTrim(LTrim(Me.RTB.Text))

        If Len(Me.RTB.Text) = 0 Then
            MsgBox("El valor no puede ser nulo..", MsgBoxStyle.OkOnly, "Seguridad del sistema")
            Exit Sub
        End If

        Dim chCar As Char = Me.RTB.Text.Substring(0)
        Dim intCar As Integer = Asc(chCar)
        If Not ((intCar >= 97 And intCar <= 122) Or (intCar >= 65 And intCar <= 90)) Then
            MessageBox.Show("El 1er Caracter debe ser un caracter válido (A..Z a..z)", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RTB.Focus()
            Return
        End If

        Glosa_Persona = Me.RTB.Text
        Close()
    End Sub

    Private Sub BtnCance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCance.Click
        Glosa_Persona = ""
        Close()
    End Sub

    Private Sub RTB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RTB.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub RTB_TextChanged(sender As System.Object, e As System.EventArgs) Handles RTB.TextChanged

    End Sub
End Class