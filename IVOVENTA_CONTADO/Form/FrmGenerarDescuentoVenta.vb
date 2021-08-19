Public Class FrmGenerarDescuentoVenta
    Dim IGV As Double
    Dim SubTotal As Double
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmGenerarDescuentoVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmGenerarDescuentoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If ObjControlDescuento.fnSP_CONTROL_DESCUENTO() = True Then
                txtOrigen.Text = ObjControlDescuento.v_ORIGEN
                txtDestino.Text = ObjControlDescuento.v_DESTINO
                txtNroGuia.Text = ObjControlDescuento.v_NRO_GUIA
                txtFormaPago.Text = ObjControlDescuento.v_FORMA_PAGO
                txtFecha.Text = ObjControlDescuento.v_FECHA_FACTURA
                txtNroBultos.Text = ObjControlDescuento.v_CANTIDAD
                txtNroSobres.Text = ObjControlDescuento.v_CANTIDAD_X_SOBRE
                txtPeso.Text = ObjControlDescuento.v_TOTAL_PESO
                txtVolumen.Text = ObjControlDescuento.v_TOTAL_VOLUMEN
                txtCliente.Text = ObjControlDescuento.v_CLIENTE
                txtFacturador.Text = ObjControlDescuento.v_CLIENTE_FACTURADOR
                txtPorcernt_Descuento.Text = ObjControlDescuento.v_MONTO_DESCUENTO
                txtMemo.Text = ObjControlDescuento.v_MEMO
                txtCostoReal.Text = ObjControlDescuento.v_TOTAL_COSTO_REAL 'v_TOTAL_COSTO
                txtSub_Total.Text = ObjControlDescuento.v_MONTO_SUB_TOTAL
                txtMonto_IGV.Text = ObjControlDescuento.v_MONTO_IMPUESTO

                txtCosto_Total.Text = ObjControlDescuento.v_TOTAL_COSTO

                txtFacturada.Text = IIf(ObjControlDescuento.V_FACTURADA = 1, "FACTURADA", "NO FACTURADA")
                txtFecha_Actualizacion.Text = ObjControlDescuento.V_FECHA_ACTUALIZACION
                txtLogin.Text = ObjControlDescuento.V_USUARIO_MODIFICAION
                txtNroGuia.Text = ObjControlDescuento.v_Comprobante_venta
                '
            Else
                Close()
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtPorcernt_Descuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcernt_Descuento.TextChanged
        Try
            If Val(txtPorcernt_Descuento.Text) > 0 Then
                txtMemo.Visible = True
                lbMemo.Visible = True
                txtMemo.Text = ""
            Else
                txtMemo.Visible = False
                lbMemo.Visible = False
                txtMemo.Text = ""
            End If
            fnCalcularCostoDescuento()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub fnCalcularCostoDescuento()

        IGV = dtoUSUARIOS.iIGV / 100
        SubTotal = txtCostoReal.Text / (1 + IGV)

        Dim SUB_TOTAL_GENERAL As Double = 0
        If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
            SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
        Else
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                SUB_TOTAL_GENERAL = 0
            End If
        End If

        'Dim SUB_TOTAL_GENERAL As Double = fnTECHO(Format((1 + IGV) * SubTotal, "###,###,###.00"))

        'Dim TotalCosto As Double = ((1 + IGV) * SubTotal) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100)

        txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
        txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
        txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")

    End Sub
    Public Function fnTECHO(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")
            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    monto_total = Val(monto_total) + 1
                    monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception

        End Try
        Return monto_total
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.F5 Then
                If Me.btnGrabar.Enabled Then
                    fnGrabar()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                Close()
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    Public Sub fnGrabar()
        Try
            If txtPorcernt_Descuento.Text = "" Then
                MsgBox("No puede Realizar Esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ObjControlDescuento.v_MONTO_DESCUENTO = txtPorcernt_Descuento.Text
            ObjControlDescuento.v_MEMO = IIf(txtMemo.Text <> "", txtMemo.Text, "NULL")
            ObjControlDescuento.v_MONTO_SUB_TOTAL = IIf(txtSub_Total.Text <> "", txtSub_Total.Text, 0)
            ObjControlDescuento.v_MONTO_IMPUESTO = IIf(txtMonto_IGV.Text <> "", txtMonto_IGV.Text, 0)
            ObjControlDescuento.v_TOTAL_COSTO = IIf(txtCosto_Total.Text <> "", txtCosto_Total.Text, 0)
            If ObjControlDescuento.fnSP_UDP_DESCUENTOS() = True Then
                Close()
            End If
        Catch ex As Exception
            MsgBox("Seguridad Sistema", MsgBoxStyle.Information, "Control de Datos...")
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        fnGrabar()
    End Sub
End Class