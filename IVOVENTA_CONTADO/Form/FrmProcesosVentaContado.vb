Public Class FrmProcesosVentaContado
    Public iControl As Integer
    Public idFacturaBoleta As Integer
    Public x_PORCENT_DEVOLUCION As Double
    Private Sub FrmProcesosVentaContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If iControl = 1 Then ' Anulacion
                txtPorcentage.Enabled = False
            End If

            If iControl = 2 Then ' devolucion
                txtPorcentage.Enabled = False
            End If

            If objControlFacturasBol.fnBuscarDatos(idFacturaBoleta) = True Then
                txtNroDoc.Text = objControlFacturasBol.nrodoc.ToString
                txtfecha.Text = objControlFacturasBol.fecha_factura
                txtCliente.Text = objControlFacturasBol.RucRazonSocial
                txtSubTotal.Text = objControlFacturasBol.Monto_Sub_Total
                txtIgv.Text = objControlFacturasBol.Monto_Impuesto.ToString
                txtPorcentage.Text = 100
                txtTotalCosto.Text = objControlFacturasBol.Total_Costo.ToString
                txtDevolucion.Text = objControlFacturasBol.Total_Costo.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If iControl = 1 Or iControl = 2 Then
                If iControl = 2 Then
                    x_PORCENT_DEVOLUCION = IIf(Val(txtPorcentage.Text) >= 0 And Val(txtPorcentage.Text) <= 100, Val(txtPorcentage.Text), 0)
                    If x_PORCENT_DEVOLUCION > 100 And x_PORCENT_DEVOLUCION < 0 Then
                        MsgBox("No puede realizar esta Opearcion de Devolucion...", MsgBoxStyle.Information, "Seguridad Sistema")
                        Return
                    End If
                Else
                    x_PORCENT_DEVOLUCION = 0
                End If
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

   

    Private Sub txtPorcentage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentage.TextChanged
        Try
            txtDevolucion.Text = Format(Val(txtTotalCosto.Text) * (1 - (Val(txtPorcentage.Text) / 100)), "##,###,###.0")
        Catch ex As Exception

        End Try
    End Sub
End Class