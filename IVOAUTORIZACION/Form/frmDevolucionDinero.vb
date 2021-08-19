Public Class frmDevolucionDinero
    Dim blnSalir As Boolean

    Private dblTotal As Double
    Public Property Total As Double
        Get
            Return dblTotal
        End Get
        Set(ByVal value As Double)
            dblTotal = value
        End Set
    End Property

    Private dblMonto As Double
    Public Property Monto() As Double
        Get
            Return dblMonto
        End Get
        Set(ByVal value As Double)
            dblMonto = value
        End Set
    End Property

    Private dblMontoNuevo As Double
    Public Property MontoNuevo() As Double
        Get
            Return dblMontoNuevo
        End Get
        Set(ByVal value As Double)
            dblMontoNuevo = value
        End Set
    End Property

    Private Sub frmDevolucionDinero_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.btnAceptar.Focus()
    End Sub

    Private Sub frmDevolucionCuentaCorriente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmDevolucionCuentaCorriente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Me.lblTotal.Text = Format(Total, "###,###,###0.00")
        Me.txtMonto.Text = Format(Monto, "0.00")
        cboDevolucionDinero.SelectedIndex = 1
    End Sub

    Private Sub cboDevolucionDinero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevolucionDinero.SelectedIndexChanged
        Me.txtMonto.Enabled = Me.cboDevolucionDinero.SelectedIndex = 1
        If txtMonto.Enabled Then
            Me.txtMonto.Text = Format(Monto, "0.00") 'Me.lblTotal.Text
            Me.btnAceptar.Focus()
        Else
            Me.txtMonto.Text = "0.00"
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text)
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        If Val(Me.txtMonto.Text) = 0 Then
            Me.txtMonto.Text = "0.00"
        Else
            Me.txtMonto.Text = Format(CType(Me.txtMonto.Text, Double), "0.00")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dblMonto As Double

        If Me.cboDevolucionDinero.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione si se devuelve o no dinero al cliente", "Devolución de Dinero", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboDevolucionDinero.Focus()
            Me.cboDevolucionDinero.DroppedDown = True
            blnSalir = False
        End If

        If Me.cboDevolucionDinero.SelectedIndex = 1 Then 'devolucion de dinero
            If Not (CType(Me.txtMonto.Text, Double) >= 1 And CType(Me.txtMonto.Text, Double) <= Monto) Then
                MessageBox.Show("El monto a devolver debe estar entre 1.00 y " & Format(Monto, "0.00"), "Devolución de Dinero", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMonto.Focus()
                blnSalir = False
                Return
            End If
        End If

        Dim dlgRespuesta As DialogResult
        Dim strMensaje As String
        Dim dblCtaCte As Double = CType(Me.lblTotal.Text, Double) - CType(Me.lblMonto.Text, Double)
        strMensaje = "Se realizará lo siguiente:" & Chr(13) & Chr(13) & "Devolución de dinero : " & Me.lblMonto.Text & Chr(13) & _
            "Cuenta corriente : " & dblCtaCte.ToString("0.00") & Chr(13) & Chr(13) & _
            "¿Está seguro de continuar?"
        dlgRespuesta = MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            blnSalir = False
        End If

    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged
        Dim dblMonto As Double
        If Val(Me.txtMonto.Text) = 0 Then
            dblMonto = MontoNuevo
        Else
            dblMonto = CType(Me.txtMonto.Text, Double) + MontoNuevo
        End If
        Me.lblMonto.Text = Format(dblMonto, "0.00")
    End Sub
End Class