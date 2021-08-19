Imports INTEGRACION_LN

Public Class frmEntregaIncidencia
    Dim blnSalir As Boolean

#Region "Propiedad"
    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property

    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property
#End Region

    Private Sub frmEntregaIncidencia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub


    Private Sub frmEntregaIncidencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Me.cboIncidencia.SelectedIndex = 0
    End Sub

    Private Sub txtObservacion_Enter(sender As Object, e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboIncidencia.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Incidencia", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboIncidencia.DroppedDown = True
            Me.cboIncidencia.Focus()
            Return
        End If

        If Me.txtObservacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Observación", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtObservacion.Text = ""
            Me.txtObservacion.Focus()
            Return
        End If

        blnSalir = True
        Grabar()
    End Sub

    Sub Grabar()
        Try
            Dim obj As New Cls_EntregaCarga_LN
            obj.GenerarIncidencia(Tipo, Comprobante, cboIncidencia.SelectedIndex, Me.txtObservacion.Text.Trim, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEntregaIncidencia_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.cboIncidencia.Focus()
    End Sub
End Class