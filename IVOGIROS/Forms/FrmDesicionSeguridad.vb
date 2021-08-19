Public Class FrmDesicionSeguridad
    Dim contador As Integer = 0
    Private Sub BtnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcep.Click
        Try



            If Me.rbcontra.Checked = False And Me.rbpregun.Checked = False Then
                MsgBox("Debe eligir un tipo de seguridad...", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub

            End If
            If rbcontra.Checked = True Then
                rgt_Desicion_Seguridad = "PASS"
            ElseIf rbpregun.Checked = True Then
                rgt_Desicion_Seguridad = "PREG"
            
            End If


            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub BtnCance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCance.Click
        Close()
        flag_Salir = True

        rgt_Desicion_Seguridad = ""
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Function
    Private Sub FrmPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flag_Salir = False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
End Class