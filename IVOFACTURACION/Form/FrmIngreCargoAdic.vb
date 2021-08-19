Public Class FrmIngreCargoAdi
    Public sIDFACTURA As String
    Public sIDTipo_Comprobante As String
    Dim objFactura As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub btnACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACEP.Click

        With objFactura
            objFactura.SERIE_FACTURA = Mid(MTBNRO_FACTURA.Text, 1, 3)
            objFactura.SERIE_FACTURA = Replace(objFactura.SERIE_FACTURA, " ", "")
            While Len(objFactura.SERIE_FACTURA) < 3
                objFactura.SERIE_FACTURA = "0" & objFactura.SERIE_FACTURA
            End While

            objFactura.NRO_FACTURA = Mid(MTBNRO_FACTURA.Text, InStr(MTBNRO_FACTURA.Text, "-") + 1, 8)
            objFactura.NRO_FACTURA = Replace(objFactura.NRO_FACTURA, " ", "")
            While Len(objFactura.NRO_FACTURA) < 8
                objFactura.NRO_FACTURA = "0" & objFactura.NRO_FACTURA
            End While

            If objFactura.NRO_FACTURA = "00000000" Then
                MsgBox("el número no es valido ", MsgBoxStyle.Exclamation, "Seguridad del sistema")
                Exit Sub
            End If

            .IP = dtoUSUARIOS.IP
            .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            .IDROL_USUARIO = dtoUSUARIOS.IdRol
            .IDFACTURA = sIDFACTURA
            .IDTIPO_COMPROBANTE = sIDTipo_Comprobante

            'datahelper
            '.SP_INSUPD_DOCUMENTOS_FACBOL(cnn)
            'SP_INSUPD_DOCUMENTOS_FACBOL()

        End With

        Close()

    End Sub

    Private Sub BTNCANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCE.Click
        Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmIngreCargoAdi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmIngreCargoAdi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmIngreCargoAdi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class