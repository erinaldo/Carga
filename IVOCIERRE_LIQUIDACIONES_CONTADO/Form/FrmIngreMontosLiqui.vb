Public Class FrmIngreMontosLiqui
    Dim bIngreso As Boolean = False
    Dim blnSalir As Boolean
    Public hnd As Long

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'MyBase.OnPaint(e)
        'Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        'Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Function validar() As Boolean
        Dim clsvalida As New ClsLbTepsa.dtoValida

        validar = False
        If clsvalida.NUMERO_NO_NEGATIVO(Me.txtmonto_soles, Me) = False Then Exit Function
        If clsvalida.NUMERO_NO_NEGATIVO(Me.txtmonto_dola, Me) = False Then Exit Function
        If clsvalida.NUMERO_NO_NEGATIVO(Me.txttipo_cambi, Me) = False Then Exit Function
        'If clsvalida.NUMERO_NO_CERO(Me.txttotal_sole, Me) = False Then Exit Function

        validar = True
    End Function
    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEP.Click
        If validar() = False Then
            blnSalir = False
            Return
        End If
        nFrmCierre_LiquiTurno.obj.Entre_Soles = Me.txtmonto_soles.Text
        nFrmCierre_LiquiTurno.obj.Entre_Dola = Me.txtmonto_dola.Text
        nFrmCierre_LiquiTurno.obj.Entre_Tipo_Cambi = Me.txttipo_cambi.Text
        'Close()
    End Sub

    Private Sub txtmonto_soles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto_soles.KeyPress
        If e.KeyChar = Chr(13) Then
            txtmonto_dola.Focus()
        End If
    End Sub

    Private Sub txtmonto_soles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmonto_soles.TextChanged

    End Sub

    Private Sub txttipo_cambi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo_cambi.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txten_soles.Focus()
        End If
    End Sub

    Private Sub txttipo_cambi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo_cambi.TextChanged

    End Sub

    Private Sub txten_soles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txten_soles.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txttotal_sole.Focus()
        End If
    End Sub

    Private Sub txttotal_sole_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal_sole.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.BTNACEP.Focus()
        End If
    End Sub

    Private Sub txtmonto_dola_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto_dola.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txttipo_cambi.Focus()
        End If
    End Sub

    Private Sub txtmonto_dola_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmonto_dola.TextChanged

    End Sub
    Private Sub calcular_total()
        If Not IsNumeric(Me.txtmonto_soles.Text) Then
            Me.txten_soles.Text = ""
            Me.txttotal_sole.Text = ""
            Exit Sub
        End If
        If Not IsNumeric(Me.txtmonto_dola.Text) Then
            Me.txten_soles.Text = ""
            Me.txttotal_sole.Text = ""
            Exit Sub
        End If
        If Not IsNumeric(Me.txttipo_cambi.Text) Then
            Me.txten_soles.Text = ""
            Me.txttotal_sole.Text = ""
            Exit Sub
        End If
        Me.txten_soles.Text = Format(CDbl(Me.txttipo_cambi.Text) * CDbl(Me.txtmonto_dola.Text), "###,###,###.00")
        Me.txttotal_sole.Text = Format(CDbl(Me.txtmonto_soles.Text) + CDbl(Me.txten_soles.Text), "###,###,###.00")
    End Sub

    Private Sub FrmIngreMontosLiqui_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmIngreMontosLiqui_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmIngreMontosLiqui_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmIngreMontosLiqui_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnSalir = True
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtmonto_soles_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto_soles.Validated
        calcular_total()
    End Sub

    Private Sub txtmonto_dola_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto_dola.Validated
        calcular_total()
    End Sub

    Private Sub txttipo_cambi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo_cambi.Validated
        calcular_total()
    End Sub

    Private Sub btncance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncance.Click
        'Close()
    End Sub
End Class