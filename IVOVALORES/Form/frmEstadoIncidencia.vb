Public Class frmEstadoIncidencia

    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property

    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
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

    Private blnLiquidado As Boolean
    Public Property Liquidado() As Boolean
        Get
            Return blnLiquidado
        End Get
        Set(ByVal value As Boolean)
            blnLiquidado = value
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

    Dim blnSalir As Boolean

    Private Sub frmEstadoIncidencia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmEstadoIncidencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        If blnNuevo Then
            Me.cboEstado.SelectedIndex = 0
        Else
            Me.dtpFecha.Value = strFecha
            Me.cboEstado.SelectedIndex = Estado
            Me.txtObservacion.Text = Observacion
            Me.cboEstado.Enabled = False

            If Liquidado Then
                Me.dtpFecha.Enabled = False
                Me.txtObservacion.Enabled = False
                Me.btnAceptar.Enabled = False
                Me.btnCancelar.Focus()
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboEstado.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione estado de la incidencia", "Estado de Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboEstado.Focus()
            Me.cboEstado.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.txtObservacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la observación", "Estado de Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacion.Text = ""
            Me.txtObservacion.Focus()
            blnSalir = False
            Return
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEstado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class