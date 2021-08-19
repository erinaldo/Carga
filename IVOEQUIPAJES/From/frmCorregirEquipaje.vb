Public Class frmCorregirEquipaje
    Dim blnSalir As Boolean
    Public intUsuario As Integer

    Private strTipoComprobante As String
    Public Property TipoComprobante() As String
        Get
            Return strTipoComprobante
        End Get
        Set(ByVal value As String)
            strTipoComprobante = value
        End Set
    End Property

    Private strNumeroComprobante As String
    Public Property NumeroComprobante() As String
        Get
            Return strNumeroComprobante
        End Get
        Set(ByVal value As String)
            strNumeroComprobante = value
        End Set
    End Property

    Private strOrigen As String
    Public Property Origen() As String
        Get
            Return strOrigen
        End Get
        Set(ByVal value As String)
            strOrigen = value
        End Set
    End Property

    Private strDestino As String
    Public Property Destino() As String
        Get
            Return strDestino
        End Get
        Set(ByVal value As String)
            strDestino = value
        End Set
    End Property


    Private Sub frmAutorizarEquipaje_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAutorizarEquipaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Val(Me.txtMonto.Text) < 0 Then
            MessageBox.Show("Ingrese el Monto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
            blnSalir = False
            Return
        End If

        If Me.txtMotivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Text = ""
            Me.txtMotivo.Focus()
            blnSalir = False
            Return
        End If

        'Dim lfrmusuario_entrega As New frmusuario_entrega
        ''
        'lfrmusuario_entrega.Lab_tip_dcto.Text = TipoComprobante 'dtGridViewControl_FACBOL.Rows(row).Cells("Tipo").Value '24/10/2008
        'lfrmusuario_entrega.txt_dcto.Text = NumeroComprobante 'dtGridViewControl_FACBOL.Rows(row).Cells("NRODOC").Value '24/10/2008
        'lfrmusuario_entrega.txt_origen.Text = Origen 'dtGridViewControl_FACBOL.Rows(row).Cells("Origen").Value
        'lfrmusuario_entrega.txt_destino.Text = Destino '1dtGridViewControl_FACBOL.Rows(row).Cells("Destino").Value
        ''
        'lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
        'lfrmusuario_entrega.txtPasswor.Focus()
        ''
        'lfrmusuario_entrega.Text = "Usuario que Autoriza"
        'lfrmusuario_entrega.ShowDialog()

        'If lfrmusuario_entrega.pb_cancelar = True Then
        '    blnSalir = False
        '    Exit Sub ' No hace nada 
        'End If
        ''
        'blnSalir = True
        'intUsuario = lfrmusuario_entrega.pl_idusuario_personal

        Dim frm As New frmUsuarioDescuento
        frm.llamada = 1
        frm.Text = "Autorizar Corrección de Monto"
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
            blnSalir = False
            Exit Sub
        End If
        blnSalir = True
        intUsuario = frm.cboUsuario.SelectedValue
    End Sub

    Private Sub txtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Enter
        txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        If Val(Me.txtMonto.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtMonto.Text)
            Me.txtMonto.Text = Format(dblMonto, "0.00")
        Else
            Me.txtMonto.Text = "0.00"
        End If
    End Sub

    Private Sub txtMotivo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMotivo.Enter
        txtMotivo.SelectAll()
    End Sub

    Private Sub txtMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtMotivo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub
End Class