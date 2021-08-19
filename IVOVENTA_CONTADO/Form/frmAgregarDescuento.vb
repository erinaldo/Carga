Public Class frmAgregarDescuento

    Dim blnSalir As Boolean

    Private Sub TxtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
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
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAutorizar.Focus()
        End If
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
            txtDescDescto.Text = ""
            If Val(TxtDescuento.Text) > 0 Then
                Me.btnAutorizar.Enabled = True
                txtDescDescto.Enabled = False
            Else
                Me.btnAutorizar.Enabled = False
                txtDescDescto.Enabled = True
                TxtDescuento.ReadOnly = False
            End If
        Else
            Me.btnAutorizar.Enabled = False
            txtDescDescto.Enabled = False
            txtDescDescto.Text = ""
        End If
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim frm As New frmUsuarioDescuento
        frm.Descuento = Me.TxtDescuento.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDescDescto.Text = frm.cboUsuario.Text
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim iDescuento As Integer
        If Me.TxtDescuento.Text.Trim = "-" Then
            iDescuento = 0
        Else
            iDescuento = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
        End If
        If iDescuento <> 0 Then
            If iDescuento < -100 Or iDescuento > 100 Then
                MessageBox.Show("Ingrese un Monto de Descuento o Incremento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDescuento.Focus()
                Me.TxtDescuento.SelectAll()
                blnSalir = False
                Return
            ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento o Incremento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescDescto.Text = ""
                txtDescDescto.Focus()
                txtDescDescto.SelectAll()
                blnSalir = False
                Return
            End If
        Else
            MessageBox.Show("Ingrese un Monto de Descuento o Incremento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtDescuento.Focus()
            Me.TxtDescuento.SelectAll()
            blnSalir = False
            Return
        End If

        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de autorizar el descuento?", "Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            blnSalir = False
        End If
    End Sub

    Private Sub frmAgregarDescuento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAgregarDescuento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blnSalir = True
    End Sub
End Class