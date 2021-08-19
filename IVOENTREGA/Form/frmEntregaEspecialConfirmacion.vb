Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmEntregaEspecialConfirmacion
    Dim intUsuario As Integer
    Dim gLista As List(Of DataGridViewRow)
    Dim blnSalir As Boolean

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub rbtSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSi.CheckedChanged
        Me.txtNumero.Text = ""
        Me.txtNombre.Text = ""
        Me.txtNumero.Enabled = True
        Me.txtNombre.Enabled = True
        Me.txtNumero.Focus()
    End Sub

    Private Sub rbtNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNo.CheckedChanged
        Me.txtNumero.Text = ""
        Me.txtNombre.Text = ""
        Me.txtNumero.Enabled = False
        Me.txtNombre.Enabled = False
        Me.btnAceptar.Focus()
    End Sub

    Private Sub txtNumero_Enter(sender As Object, e As System.EventArgs) Handles txtNumero.Enter
        Me.txtNumero.SelectAll()
    End Sub

    Private Sub txtNombre_Enter(sender As Object, e As System.EventArgs) Handles txtNombre.Enter
        Me.txtNombre.SelectAll()
    End Sub

    Private Sub dtpFechaEntrega_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaEntrega.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpHoraEntrega_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpHoraEntrega.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtSi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles rbtSi.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles rbtNo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.rbtSi.Checked Then
            If Me.txtNumero.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº Documento", "Entrega Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.txtNumero.Focus()
                Return
            End If
            If Me.txtNumero.Text.Trim.Length = 11 Then
                If Not fnValidarRUC(Me.txtNumero.Text) Then
                    MessageBox.Show("Ingrese RUC válido", "Entrega Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.txtNumero.Focus()
                    Return
                End If
            Else
                If Me.txtNumero.Text.Trim.Length <> 8 Then
                    MessageBox.Show("Ingrese DNI válido", "Entrega Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.txtNumero.Focus()
                    Return
                End If
            End If

            If Me.txtNombre.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres", "Entrega Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.txtNombre.Text = ""
                Me.txtNombre.Focus()
                Return
            End If
        End If

        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Realizar la Entrega?", "Entrega Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            blnSalir = False
            Return
        End If


        Dim frmUsuarioConfirmar As New frmUsuarioValor

        frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
        frmUsuarioConfirmar.txtUsuario.Text = dtoUSUARIOS.iLOGIN
        frmUsuarioConfirmar.txtContraseña.Focus()

        frmUsuarioConfirmar.ShowDialog()
        If frmUsuarioConfirmar.Resultado = 0 Then
            blnSalir = False
            Return
        End If
        intUsuario = frmUsuarioConfirmar.IDUsuario

        Aceptar()
    End Sub

    Public Sub Cargar(lista As List(Of DataGridViewRow))
        gLista = lista
    End Sub

    Sub Aceptar()
        Try
            Dim objLN As New Cls_EntregaCarga_LN

            For Each row As DataGridViewRow In gLista
                objLN.GrabarEntrega(row.Cells("idtipo_comprobante").Value, row.Cells("id").Value, dtpFechaEntrega.Value, dtpHoraEntrega.Value.ToShortTimeString, _
                                    Me.txtNombre.Text.Trim, Me.txtNumero.Text.Trim, intUsuario, dtoUSUARIOS.IP)
            Next

            MessageBox.Show("Entrega Realizada", "Entrega Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEntregaEspecialConfirmacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmEntregaEspecialConfirmacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
    End Sub
End Class