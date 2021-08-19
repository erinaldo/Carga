Imports INTEGRACION_LN
Public Class frmLiquidarRemesa
    Public intBanco As Integer
    Public intCuentaCorriente As Integer
    Public strFecha As String
    Public strNumero As String
    Public intTipoMoneda As Integer
    Public intIncidencia As Integer
    Public dblMonto As Double

    Dim blnSalir As Boolean
    Dim dtCuentaCorriente As DataTable

    Private Sub frmLiquidarRemesa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Sub ListarBanco()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboBanco
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarBanco()
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarCuentaCorriente(ByVal banco As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboCuentaCorriente
            dtCuentaCorriente = obj.ListarCuentaCorriente(banco)
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dtCuentaCorriente
            .SelectedValue = 0
        End With
    End Sub

    Private Sub frmLiquidarRemesa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        ListarBanco()
        Me.cboBanco.SelectedValue = intBanco
        Me.cboCuentaCorriente.SelectedValue = intCuentaCorriente
        Me.txtMonto.Text = Format(dblMonto, "0.00")
        If strFecha.Trim.Length > 0 Then
            Me.dtpFecha.Value = strFecha.Trim
            Me.txtNumero.Text = strNumero.Trim
            Me.dtpFecha.Checked = True
            Me.btnAceptar.Focus()
        Else
            Me.dtpFecha.Checked = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If intIncidencia = 0 Then
            If Me.cboBanco.SelectedValue = 0 Then
                MessageBox.Show("Seleccione el banco", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboBanco.Focus()
                Me.cboBanco.DroppedDown = True
                blnSalir = False
                Return
            End If

            If Me.cboCuentaCorriente.SelectedValue = 0 Then
                MessageBox.Show("Seleccione la cuenta corriente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCuentaCorriente.Focus()
                Me.cboCuentaCorriente.DroppedDown = True
                blnSalir = False
                Return
            End If
        Else
            If Me.cboBanco.SelectedValue = 0 And Me.cboCuentaCorriente.SelectedValue > 0 Then
                MessageBox.Show("Seleccione el banco", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboBanco.Focus()
                Me.cboBanco.DroppedDown = True
                blnSalir = False
                Return
            End If

            If Me.cboBanco.SelectedValue > 0 And Me.cboCuentaCorriente.SelectedValue = 0 Then
                MessageBox.Show("Seleccione la cuenta corriente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCuentaCorriente.Focus()
                Me.cboCuentaCorriente.DroppedDown = True
                blnSalir = False
                Return
            End If
        End If

        If dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda") <> intTipoMoneda And dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda") > 0 Then
            MessageBox.Show("El tipo de moneda seleccionado no coincide con el de la remesa", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCuentaCorriente.Focus()
            Me.cboCuentaCorriente.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Not Me.dtpFecha.Checked Then
            MessageBox.Show("Seleccione Fecha de Operación", "Liquidación de Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            blnSalir = False
            Return
        End If

        Dim blnOk As Boolean
        If intIncidencia = 0 Then
            blnOk = Val(Me.txtNumero.Text) > 0
        Else
            blnOk = Me.txtNumero.Text.Trim.Length > 0
        End If
        If Not blnOk Then
            MessageBox.Show("Ingrese Nº/Desc. de Operación", "Liquidación de Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            blnSalir = False
            Return
        End If

        If Me.chkMonto.Checked Then
            If Val(Me.txtMonto.Text) = 0 Then
                MessageBox.Show("El Monto debe ser mayor a 0", "Liquidación de Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMonto.Focus()
                blnSalir = False
                Return
            End If
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
            'ElseIf Not ValidarNumero(e.KeyChar) Then
            'e.Handled = True
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
        Dim intBanco As Integer
        intBanco = Me.cboBanco.SelectedValue
        ListarCuentaCorriente(intBanco)
    End Sub

    Private Sub txtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Enter
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        Dim dblMonto As Double
        If Val(Me.txtMonto.Text) > 0 Then
            dblMonto = CDbl(Me.txtMonto.Text)
        Else
            dblMonto = 0
        End If
        Me.txtMonto.Text = Format(dblMonto, "0.00")
    End Sub

    Private Sub chkMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonto.CheckedChanged
        If Me.chkMonto.Checked Then
            Me.txtMonto.Enabled = True
            Me.txtMonto.Focus()
        Else
            Me.txtMonto.Enabled = False
            Me.txtMonto.Text = Format(dblMonto, "0.00")
        End If
    End Sub
End Class