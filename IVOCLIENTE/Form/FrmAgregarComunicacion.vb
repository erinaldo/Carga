Imports INTEGRACION_LN

Public Class FrmAgregarComunicacion
    Public intOpcion As Integer
    Dim blnSalir As Boolean = True

#Region "Propiedades"
    Private intTipoComunicacion As String
    Public Property TipoComunicacion() As Integer
        Get
            Return intTipoComunicacion
        End Get
        Set(ByVal value As Integer)
            intTipoComunicacion = value
        End Set
    End Property

    Private strNumeroComunicacion As String
    Public Property NumeroComunicacion() As String
        Get
            Return strNumeroComunicacion
        End Get
        Set(ByVal value As String)
            strNumeroComunicacion = value
        End Set
    End Property

#End Region

    Private Sub FrmAgregarComunicacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            e.Cancel = True
            blnSalir = True
        End If
    End Sub

    Private Sub FrmAgregarContacto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim objLN As New Cls_Contacto_LN()
        Dim dt As DataTable = objLN.ListarComunicacion
        Me.cboTipoComunicacion.DisplayMember = "tipo"
        Me.cboTipoComunicacion.ValueMember = "id"
        Me.cboTipoComunicacion.DataSource = dt
        Me.cboTipoComunicacion.SelectedValue = 0

        If intOpcion = 2 Then
            Me.cboTipoComunicacion.SelectedValue = intTipoComunicacion
            Me.txtNumeroComunicacion.Text = strNumeroComunicacion
        End If
    End Sub

    Private Sub txtNumeroComunicacion_Enter(sender As Object, e As System.EventArgs) Handles txtNumeroComunicacion.Enter
        Me.txtNumeroComunicacion.SelectAll()
    End Sub

    Private Sub txtNumeroComunicacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComunicacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboTipoComunicacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Comunicación", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoComunicacion.Focus()
            blnSalir = False
            Return
        End If

        If Me.txtNumeroComunicacion.Text.Trim.Length = 0 Then
            blnSalir = False
        Else
            If Me.txtNumeroComunicacion.Text.Trim.Length < 7 Then
                blnSalir = False
            End If
        End If

        If blnSalir = False Then
            MessageBox.Show("Ingrese Nº de Comunicación", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroComunicacion.Focus()
            Return
        End If
    End Sub

    Private Sub cboTipoComunicacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoComunicacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
End Class