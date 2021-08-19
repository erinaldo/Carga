'Imports AccesoDatos
Public Class frmDescuento
    Public sCliente As String
    Public sDocumento As String
    Public iId As String
    Public iDescuento As Double
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.Close()
    End Sub

    Private Sub txtDescuento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescuento.GotFocus
        txtDescuento.SelectAll()
    End Sub

    Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = "." Then
                If Not (tb.SelectedText = ".") Then
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                    e.Handled = True
                End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            ElseIf Asc(e.KeyChar) = 13 Then
                btnSi.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub frmDescuento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmDescuento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            txtDocumento.Text = sDocumento
            txtCliente.Text = sCliente
            txtDescuento.Text = Format(iDescuento, "0.00")

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'Public Function sp_upd_descuento2009_eliminarlo() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"sp_upd_descuento", 6, iId, 2, iDescuento, 3}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function

    Private Sub btnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSi.Click
        Try
            iDescuento = Val(IIf(txtDescuento.Text = "", 0, txtDescuento.Text))
            If iDescuento > 0 Then      'descuento
                If Not (iDescuento >= 1 And iDescuento <= 100) Then
                    MessageBox.Show("El % de Descuento debe estar entre 1.00 y 100.00", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDescuento.SelectAll()
                    txtDescuento.Focus()
                    Exit Sub
                End If
            ElseIf iDescuento < 0 Then  'incremento
                If Not (Abs(iDescuento) >= 1 And Abs(iDescuento) <= 999) Then
                    MessageBox.Show("El % de Incremento debe estar entre 1.00 y 999.00", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDescuento.SelectAll()
                    txtDescuento.Focus()
                    Exit Sub
                End If
            End If

            Dim iResp As Integer
            iResp = MessageBox.Show("¿Está Seguro de Realizar la Actualización?", "Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If iResp = vbYes Then
                'datahelper
                Dim rst As DataTable
                rst = sp_upd_descuento()
                If rst.Rows(0).Item(0).ToString = 0 Then
                    MessageBox.Show("Se Realizó la Actualización", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Close()
                    FrmClientes.bActualizado = True
                End If
            End If
            '    Dim rst As ADODB.Recordset
            '    rst = sp_upd_descuento()
            '    If rst(0).Value = 0 Then
            '        MessageBox.Show("Se Realizó la Actualización", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Close()
            '        FrmClientes.bActualizado = True
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function sp_upd_descuento() As DataTable
        Try
            Dim obj As New dtoCLIENTES
            Return obj.upd_descuento(iId, iDescuento)

        Catch ex As Exception
            'MsgBox(ex.Excepcion, MsgBoxStyle.Critical, "Sistema de Seguridad")
            Throw New Exception(ex.Message)
            'Return Nothing
        End Try
    End Function

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtDescuento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescuento.TextChanged

    End Sub
End Class