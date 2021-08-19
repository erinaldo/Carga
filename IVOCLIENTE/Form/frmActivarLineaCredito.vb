Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmActivarLineaCredito
    Dim blnSalir As Boolean = True
    Dim dblMonto As Double = 0
#Region "Propiedades"
    Private intLlamada As Integer
    Public Property Llamada() As Integer
        Get
            Return intLlamada
        End Get
        Set(ByVal value As Integer)
            intLlamada = value
        End Set
    End Property


    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
        End Set
    End Property

    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property

    Private strRuc As String
    Public Property Ruc() As String
        Get
            Return strRuc
        End Get
        Set(ByVal value As String)
            strRuc = value
        End Set
    End Property

    Private strRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return strRazonSocial
        End Get
        Set(ByVal value As String)
            strRazonSocial = value
        End Set
    End Property

#End Region

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub frmActivarLineaCredito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmActivarLineaCredito_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = IIf(Llamada = 1, "Activar Línea de Crédito", "Actualizar Línea de Crédito")
        Me.lblCodigoCliente.Text = Ruc
        Me.lblRazonSocial.Text = RazonSocial

        Dim obj As New Cls_LineaCredito_LN
        Dim dt As DataTable = obj.ListarLineaCreditoUltima(Cliente, IIf(Llamada = 1, 0, 1))
        If dt.Rows.Count > 0 Then
            Me.lblLineaCredito.Text = Format(dt.Rows(0).Item("linea"), "0.00")
            Me.lblTotalAsignado.Text = Format(dt.Rows(0).Item("total"), "0.00")
            Me.lblSobregiro.Text = Format(dt.Rows(0).Item("sobregiro"), "0.00")
            Me.lblSaldo.Text = Format(dt.Rows(0).Item("saldo"), "0.00")
            Me.txtMonto.Text = Format(dt.Rows(0).Item("linea"), "0.00")
            dblMonto = Me.txtMonto.Text
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Val(Me.txtMonto.Text) = 0 Then
            MessageBox.Show("Ingrese Monto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtMonto.Focus()
            Return
        End If

        If Llamada = 2 Then
            If dblMonto = CType(Me.txtMonto.Text, Double) Then
                MessageBox.Show("El Monto debe ser diferente a " & dblMonto, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.txtMonto.Focus()
                Return
            End If
        End If

        Aceptar()
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As System.EventArgs) Handles txtMonto.Enter
        Dim dblValor As Double = 0
        If Me.txtMonto.Text.Trim.Length = 0 Then
            dblValor = 0
        Else
            dblValor = Me.txtMonto.Text
        End If
        Me.txtMonto.Text = Format(CDbl(dblValor), "########0.00")
    End Sub

    Private Sub txtMonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtMonto.GotFocus
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMonto_LostFocus(sender As Object, e As System.EventArgs) Handles txtMonto.LostFocus
        Dim dblValor As Double = 0
        If Me.txtMonto.Text.Trim.Length = 0 Then
            dblValor = 0
        Else
            dblValor = Me.txtMonto.Text
        End If
        Me.txtMonto.Text = Format(CDbl(dblValor), "########0.00")
    End Sub

    Private Sub txtMonto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonto.TextChanged
    End Sub

    Sub Aceptar()
        Try
            Dim dblMontoTotal As Double = 0
            'If dblMonto = CType(Me.txtMonto.Text, Double) Then
            'dblMontoTotal = 0
            'Else
            dblMontoTotal = CType(Me.txtMonto.Text, Double)
            'End If

            Dim objLN As New Cls_LineaCredito_LN
            objLN.ActivarDesactivar(ID, Cliente, 1, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblMontoTotal)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class