Public Class frmMontoFueraZona

    Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double
    Dim blnSalir As Boolean

    Private dblTotalfz As Double
    Public Property TotalFZ() As Double
        Get
            Return dblTotalfz
        End Get
        Set(ByVal value As Double)
            dblTotalfz = value
        End Set
    End Property

    Private Sub frmMontoFueraZona_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMontoFueraZona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        dblTotal = TotalFZ
        dblSubtotal = dblTotal / 1.18
        dblImpuesto = dblTotal / 1.18 * 0.18
        Mostrar(dblSubtotal, dblImpuesto, dblTotal)
    End Sub

    Private Sub txtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Enter
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMonto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Leave
        Dim dblMonto As Double
        If Val(Me.txtMonto.Text) = 0 Then
            dblMonto = 0
        Else
            dblMonto = CType(Me.txtMonto.Text, Double)
        End If
        Me.txtMonto.Text = Format(dblMonto, "0.00")
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged
        Dim fz As Double, total As Double, subtotal As Double, impuesto As Double

        If Val(Me.txtMonto.Text) = 0 Then
            fz = 0
        Else
            fz = CType(Me.txtMonto.Text, Double)
        End If
        fz = fz * 1.18
        total = dblTotal + fz
        subtotal = total / 1.18
        impuesto = total / 1.18 * 0.18

        Mostrar(subtotal, impuesto, total)
    End Sub

    Sub Mostrar(ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double)
        Me.lblSubtotal.Text = Format(subtotal, "0.00")
        Me.lblImpuesto.Text = Format(impuesto, "0.00")
        Me.lblTotal.Text = Format(total, "0.00")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Val(Me.txtMonto.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto", "Cambio de Monto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtMonto.Focus()
            Me.txtMonto.SelectAll()
        End If
    End Sub
End Class