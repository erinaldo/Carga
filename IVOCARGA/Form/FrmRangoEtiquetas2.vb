Public Class FrmRangoEtiquetas2
#Region "Variables Publicas"
    Dim blnSalir As Boolean
    Public total_bultos As Long
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
    Private Sub rbtodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtodos.CheckedChanged
        Me.NumeUDini.Enabled = False
        Me.NumeUDfinal.Enabled = False
    End Sub

    Private Sub rbrango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbrango.CheckedChanged
        Me.NumeUDini.Enabled = True
        Me.NumeUDfinal.Enabled = True
    End Sub

    Private Sub btnCance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCance.Click
        correlativo_inicial = -1
        correlativo_final = -1
        Close()
    End Sub

    Private Sub btnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcep.Click
        If Me.rbrango.Checked = True Then
            If total_bultos < Me.NumeUDfinal.Value Then
                If MsgBox("La cantidad final no puede ser mayor que el total bultos...", MsgBoxStyle.Critical, "Seguridad Sistemas") Then
                    blnSalir = False
                    Exit Sub
                End If
            End If
            If Me.NumeUDini.Value < 1 Then
                If MsgBox("La cantidad inicial no puede ser menor o igual que cero...", MsgBoxStyle.Critical, "Seguridad Sistemas") Then
                    blnSalir = False
                    Exit Sub
                End If
            End If
            If Me.NumeUDini.Value > Me.NumeUDfinal.Value Then
                If MsgBox("La cantidad inicial no puedeo ser mayor que la final...", MsgBoxStyle.Critical, "Seguridad Sistemas") Then
                    blnSalir = False
                    Exit Sub
                End If
            End If
        End If

        If Me.rbtodos.Checked = True Then
            correlativo_inicial = 0
            correlativo_final = 0
        Else
            correlativo_inicial = Me.NumeUDini.Value
            correlativo_final = Me.NumeUDfinal.Value
        End If

        Close()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmRangoEtiquetas2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRangoEtiquetas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            blnSalir = True
            Label3.Text = "Total Bultos = " + CLng(total_bultos).ToString

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class