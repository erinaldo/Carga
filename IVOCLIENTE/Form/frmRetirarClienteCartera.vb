Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmRetirarClienteCartera
    Dim intResponsable As Integer
    Dim gLista As List(Of DataGridViewRow)
    Dim blnSalir As Boolean = True

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub frmRetirarClienteCartera_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmRetirarClienteCartera_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Me.dtpFechaFin.Value = Now.ToString("dd/MM/yyyy")

        Me.chkDesactivar.Checked = False
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Retirar de la Cartera los Clientes Seleccionados?", "Retirar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Aceptar()
        Else
            blnSalir = False
        End If
    End Sub

    Sub Aceptar()
        Try
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            Dim intOperacion As Integer = 0
            If Me.chkDesactivar.Checked Then
                intOperacion = 1
            ElseIf Me.chkCancelar.Checked Then
                intOperacion = 2
            Else
                intOperacion = 0
            End If
            For Each row As DataGridViewRow In gLista
                objEN.Cliente = row.Cells("id").Value
                objEN.ResponsableActual = intResponsable
                objEN.ResponsableFechaFin = Me.dtpFechaFin.Value
                objEN.Usuario = dtoUSUARIOS.IdLogin
                objEN.IP = dtoUSUARIOS.IP
                objLN.RetirarClienteCartera(objEN, intOperacion)
            Next
            MessageBox.Show("Cuenta Actualizada", "Retirar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Cargar(responsable As Integer, lista As List(Of DataGridViewRow))
        intResponsable = responsable
        gLista = lista
    End Sub

    Private Sub dtpFechaFin_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaFin.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged

    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked Then
            chkCancelar.Checked = False
            Me.lblMensaje.Text = "DESACTIVAR LINEA DE CREDITO"
        Else
            If Not chkCancelar.Checked Then
                Me.lblMensaje.Text = ""
            End If
        End If
    End Sub

    Private Sub chkDesactivar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chkDesactivar.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub chkCancelar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCancelar.CheckedChanged
        If chkCancelar.Checked Then
            chkDesactivar.Checked = False
            Me.lblMensaje.Text = "CANCELAR LINEA DE CREDITO"
        Else
            If Not chkDesactivar.Checked Then
                Me.lblMensaje.Text = ""
            End If
        End If
    End Sub

    Private Sub chkCancelar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chkCancelar.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
End Class