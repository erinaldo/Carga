Imports INTEGRACION_LN
Public Class frmLiquidacionParcial

    Dim dtCuentaCorriente As DataTable
    Public intTipoMoneda As Integer

    Private intBanco As Integer
    Public Property Banco() As Integer
        Get
            Return intBanco
        End Get
        Set(ByVal value As Integer)
            intBanco = value
        End Set
    End Property

    Private intCuentaCorriente As Integer
    Public Property CuentaCorriente() As Integer
        Get
            Return intCuentaCorriente
        End Get
        Set(ByVal value As Integer)
            intCuentaCorriente = value
        End Set
    End Property

    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property

    Private strNumero As String
    Public Property Numero() As String
        Get
            Return strNumero
        End Get
        Set(ByVal value As String)
            strNumero = value
        End Set
    End Property

    Private strObservacion As String
    Public Property Observacion() As String
        Get
            Return strObservacion
        End Get
        Set(ByVal value As String)
            strObservacion = value
        End Set
    End Property

    Private blnNuevo As Boolean
    Public Property Nuevo() As Boolean
        Get
            Return blnNuevo
        End Get
        Set(ByVal value As Boolean)
            blnNuevo = value
        End Set
    End Property

    Private dblMontoTotal As Double
    Public Property MontoTotal() As Double
        Get
            Return dblMontoTotal
        End Get
        Set(ByVal value As Double)
            dblMontoTotal = value
        End Set
    End Property

    Private dblMontoDepositado As Double
    Public Property MontoDepositado As Double
        Get
            Return dblMontoDepositado
        End Get
        Set(ByVal value As Double)
            dblMontoDepositado = value
        End Set
    End Property

    Private dblMontoDepositadoTmp As Double
    Public Property MontoDepositadoTmp As Double
        Get
            Return dblMontoDepositadoTmp
        End Get
        Set(ByVal value As Double)
            dblMontoDepositadoTmp = value
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

    Private blnEditable As Boolean
    Public Property Editable() As Boolean
        Get
            Return blnEditable
        End Get
        Set(ByVal value As Boolean)
            blnEditable = value
        End Set
    End Property


    Dim blnSalir As Boolean

    Private Sub frmLiquidacionParcial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmLiquidacionParcial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        blnSalir = True
        ListarBanco()
        Me.lblMontoTotal.Text = Format(MontoTotal, "###,###,###.00")
        Me.lblMontoDepositado.Text = Format(MontoDepositado, "###,###,###.00")
        Me.lblSaldo.Text = Format(MontoTotal - MontoDepositado, "###,###,###0.00")
        If Not blnNuevo Then
            Me.cboBanco.SelectedValue = Banco
            Me.cboCuentaCorriente.SelectedValue = CuentaCorriente
            Me.dtpFecha.Value = Fecha
            Me.dtpFecha.Checked = True
            Me.txtNumero.Text = Numero
            Me.txtMonto.Text = Format(Monto, "0.00")
            Me.txtObservacion.Text = Observacion
            If Not Editable Then
                Me.dtpFecha.Enabled = False
                Me.txtNumero.Enabled = False
                Me.txtMonto.Enabled = False
                Me.txtObservacion.Enabled = False
                Me.btnAceptar.Enabled = False
                Me.btnCancelar.Focus()
            End If
        End If
    End Sub

    Private Sub txtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Enter
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
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

    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
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

        If dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda") <> intTipoMoneda And dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda") > 0 Then
            MessageBox.Show("El tipo de moneda seleccionado no coincide con el de la remesa", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCuentaCorriente.Focus()
            Me.cboCuentaCorriente.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Not Me.dtpFecha.Checked Then
            MessageBox.Show("Seleccione Fecha de Operación", "Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            blnSalir = False
            Return
        End If

        If Val(Me.txtNumero.Text) = 0 Then
            MessageBox.Show("Ingrese Nº de Operación", "Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            blnSalir = False
            Return
        End If

        If Val(Me.txtMonto.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto", "Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtMonto.Focus()
            Return
        End If

        Dim dblSaldo As Double
        dblSaldo = CType(Me.lblSaldo.Text, Double)
        'If dblSaldo < 0 Then
        'MessageBox.Show("El monto depositado no debe ser mayor al monto total", "Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'blnSalir = False
        'Me.txtMonto.Focus()
        'Return
        'End If

        If Me.txtObservacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la Observación", "Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtObservacion.Text = ""
            Me.txtObservacion.Focus()
            Return
        End If
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged
        Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblSaldo As Double
        Dim dblMonto As Double
        dblMontoTotal = CType(Me.lblMontoTotal.Text, Double)
        If Not Nuevo Then
            If Val(Me.txtMonto.Text) = 0 Then
                dblMontoDepositado = 0
            Else
                dblMontoDepositado = CType(Me.txtMonto.Text, Double)
            End If
            dblMontoDepositado = dblMontoDepositado + dblMontoDepositadoTmp
            dblSaldo = dblMontoTotal - dblMontoDepositado
        Else
            If Val(Me.txtMonto.Text) = 0 Then
                dblMonto = 0
            Else
                dblMonto = CType(Me.txtMonto.Text, Double)
            End If
            dblMontoDepositado = dblMonto + dblMontoDepositadoTmp
            dblSaldo = dblMontoTotal - dblMontoDepositado
        End If
        Me.lblMontoDepositado.Text = Format(dblMontoDepositado, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub

    Private Sub txtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Enter
        Me.txtNumero.SelectAll()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
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

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
        Dim intBanco As Integer
        intBanco = Me.cboBanco.SelectedValue
        ListarCuentaCorriente(intBanco)
    End Sub
End Class