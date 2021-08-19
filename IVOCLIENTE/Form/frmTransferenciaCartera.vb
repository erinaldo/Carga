Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmTransferenciaCartera
    Dim intCliente As Integer
    Dim intFuncionario1 As Integer
    Dim intFuncionario2 As Integer
    Dim strFuncionario1 As String
    Dim strFuncionario2 As String
    Dim gLista As List(Of DataGridViewRow)

    Dim blnSalir As Boolean

    Private Sub frmTransferenciaCartera_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmTransferenciaCartera_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True

        Me.lblFuncionario1.Text = strFuncionario1
        Me.lblFuncionario2.Text = strFuncionario2

        Me.dtpFechaFin.Value = Date.Now.ToString("dd/MM/yyyy")
        Me.dtpFechaVigencia.Value = DateAdd("d", 1, Now).ToString("dd/MM/yyyy")
    End Sub

    Public Sub Cargar(f1 As Integer, sf1 As String, f2 As Integer, sf2 As String, lista As List(Of DataGridViewRow))
        intFuncionario1 = f1
        intFuncionario2 = f2
        strFuncionario1 = sf1
        strFuncionario2 = sf2
        gLista = lista
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        'If Me.dtpFechaFin.Text.CompareTo(Me.dtpFechaVigencia.Text) >= 0 Then
        If Date.Compare(dtpFechaFin.Value, dtpFechaVigencia.Value) >= 0 Then
            MessageBox.Show("La Fecha Inicio " & Format(Me.dtpFechaVigencia.Value, "short date") & " de Nueva Cartera debe ser mayor a la " & Chr(13) & "Fecha Fin " & Format(Me.dtpFechaFin.Value, "short date") & " de Cartera Actual", "Transferir", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFechaFin.Focus()
            blnSalir = False
            Return
        End If

        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Realizar la Transferencia?", "Transferir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
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

            For Each row As DataGridViewRow In gLista
                objEN.Cliente = row.Cells("id").Value
                objEN.ResponsableActual = intFuncionario1
                objEN.Responsable = intFuncionario2
                objEN.Fecha = Me.dtpFechaVigencia.Text
                objEN.ResponsableFechaFin = Me.dtpFechaFin.Text
                objEN.Usuario = dtoUSUARIOS.IdLogin
                objEN.IP = dtoUSUARIOS.IP
                objLN.TransferirCuenta(objEN)

            Next
            MessageBox.Show("Transferencia Realizada", "Transferir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaVigencia_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaVigencia.ValueChanged
        'If Me.dtpFechaFin.Value < Me.dtpFechaVigencia.Value Then
        '    Me.dtpFechaFin.Text = Format(DateAdd("d", -1, dtpFechaVigencia.Value), "short date")
        'End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged

    End Sub
End Class