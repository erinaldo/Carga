Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmDevolucionCargoDetalle
    Dim blnSalir As Boolean

    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
        End Set
    End Property

    Private intTipo As Integer
    Public Property IdTipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property

    Private intComprobante As Integer
    Public Property IdComprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

    Private strTipo As String
    Public Property Tipo() As String
        Get
            Return strTipo
        End Get
        Set(ByVal value As String)
            strTipo = value
        End Set
    End Property

    Private strComprobante As String
    Public Property Comprobante() As String
        Get
            Return strComprobante
        End Get
        Set(ByVal value As String)
            strComprobante = value
        End Set
    End Property

    Private strSerie As String
    Public Property Serie() As String
        Get
            Return strSerie
        End Get
        Set(ByVal value As String)
            strSerie = value
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

    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property

    Private intOpcion As Integer
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property

    Private Sub frmDevolucionCargoDetalle_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmDevolucionCargoDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True

        Me.lblTipo.Text = Tipo
        Me.lblComprobante.Text = Comprobante

        Me.txtSerie.Text = Serie
        Me.txtNumero.Text = Numero
    End Sub

    Private Sub txtSerie_Enter(sender As Object, e As System.EventArgs) Handles txtSerie.Enter
        Me.txtSerie.SelectAll()
    End Sub

    Private Sub txtNumero_Enter(sender As Object, e As System.EventArgs) Handles txtNumero.Enter
        Me.txtNumero.SelectAll()
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
            'Else
            '    If Not (ValidarNumero(e.KeyChar)) Then
            '        e.Handled = True
            '    End If
        End If
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        Else
            If Not (ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'If Val(Me.txtSerie.Text) = 0 Then
        If Me.txtSerie.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº Serie", "Grabar Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtSerie.Focus()
            Return
        End If

        If Val(Me.txtNumero.Text) = 0 Then
            MessageBox.Show("Ingrese Nº Documento", "Grabar Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtNumero.Focus()
            Return
        End If

        Aceptar()
        Close()
    End Sub

    Private Sub frmDevolucionCargoDetalle_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.txtSerie.Focus()
    End Sub

    Sub Aceptar()
        Try
            If Opcion = 0 Then
                Dim obj As New Cls_DevolucionCargo_LN
                obj.GrabarCargo(ID, IdTipo, IdComprobante, Me.txtSerie.Text, Me.txtNumero.Text, Cliente, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            End If

        Catch ex As Exception
            blnSalir = False
            MessageBox.Show(ex.Message, "Grabar Cargo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub
End Class