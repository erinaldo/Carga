Imports INTEGRACION_LN
Public Class frmIncidenciaValor
    Private intIncidencia As Integer
    Public Property Incidencia() As Integer
        Get
            Return intIncidencia
        End Get
        Set(ByVal value As Integer)
            intIncidencia = value
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

    Private Sub frmIncidenciaValor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmIncidenciaValor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        ListarIncidencia()
        Me.lblMontoTotal.Text = Format(MontoTotal, "###,###,###.00")
        Me.lblMontoDepositado.Text = Format(MontoDepositado, "###,###,###.00")
        Me.lblSaldo.Text = Format(MontoTotal - MontoDepositado, "###,###,###0.00")
        If Not blnNuevo Then
            Me.cboIncidencia.Enabled = False
            Me.cboIncidencia.SelectedValue = Incidencia
            Me.txtMonto.Text = Format(Monto, "0.00")
            Me.txtObservacion.Text = Observacion
            If Not Editable Then
                Me.cboIncidencia.Enabled = False
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

    Sub ListarIncidencia()
        Dim obj As New UtilData_LN
        Dim dt As DataTable = obj.TipoControl(17, 2)
        With Me.cboIncidencia
            .DisplayMember = "descripcion"
            .ValueMember = "codigo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub cboIncidencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboIncidencia.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboIncidencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIncidencia.SelectedIndexChanged
        Me.txtMonto.Focus()
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
        If Me.cboIncidencia.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la Incidencia", "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboIncidencia.Focus()
            Me.cboIncidencia.DroppedDown = True
            Return
        End If

        If Me.txtMonto.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Monto", "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtMonto.Focus()
            Return
        End If

        'Dim dblSaldo As Double
        'dblSaldo = CType(Me.lblSaldo.Text, Double)
        'If dblMontoTotal < dblSaldo Then
        '    MessageBox.Show("El monto con Incidencia no debe ser mayor al monto total", "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    blnSalir = False
        '    Me.txtMonto.Focus()
        '    Return
        'End If

        If Me.txtObservacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la Observación", "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dblMontoDepositado = dblMontoTotal - (dblMontoDepositado + dblMontoDepositadoTmp)
            dblSaldo = dblMontoTotal - dblMontoDepositado
        Else
            If Val(Me.txtMonto.Text) = 0 Then
                dblMonto = 0
            Else
                dblMonto = CType(Me.txtMonto.Text, Double)
            End If
            dblMontoDepositado = dblMontoTotal - (dblMonto + dblMontoDepositadoTmp)
            If dblMonto + dblMontoDepositadoTmp = 0 Then dblMontoDepositado = 0
            dblSaldo = dblMontoTotal - dblMontoDepositado
        End If
        Me.lblMontoDepositado.Text = Format(dblMontoDepositado, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub

    Private Sub txtObservacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacion.TextChanged

    End Sub
End Class