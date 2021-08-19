
Public Class FrmLineaCredito
    Public sDocumento As String
    Public sCliente As String
    Public iId As String
    Public sAccion As String
    Public rsTipoFacturacion As DataTable
    Dim IdTipo_Facturacion As Integer
    Dim bIngreso As Boolean = False
    Public iSolicitud As Integer
    Public hnd As Long
#Region "Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

    Private Sub FrmLineaCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    '
    Private Sub FrmLineaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtDocumento.Text = sDocumento
            txtCliente.Text = sCliente
            If sAccion = "A" Then
                Me.Text = "Activar Línea de Crédito"
                btnSi.Text = "&Activar"
            Else
                Me.Text = "Desactivar Línea de Crédito"
                btnSi.Text = "&Desactivar"
            End If

            Dim rst As DataTable
            rst = SP_Linea_Credito()
            If rst.Rows.Count > 0 Then
                txtTotal.Text = FormatNumber(rst.Rows(0).Item("total").ToString, 2)
                txtSobregiro.Text = FormatNumber(rst.Rows(0).Item("sobregiro").ToString, 2)
                txtSaldo.Text = FormatNumber(rst.Rows(0).Item("saldo").ToString, 2)
                lblDatoFecha.Text = rst.Rows(0).Item("Fecha_Desactivacion").ToString

                If sAccion = "A" Then
                    Dim dvTipoFacturacion As DataView
                    Dim dtTipoFacturacion As New System.Data.DataTable
                    dvTipoFacturacion = Funciones.CargarCombo(cmbTipoFacturacion, rsTipoFacturacion, "TIPO_FACTURACION", "IDTIPO_FACTURACION", -1)
                    cmbTipoFacturacion.SelectedValue = rst.Rows(0).Item("Idtipo_Facturacion").ToString

                    lblTipoFacturacion.Visible = True
                    cmbTipoFacturacion.Visible = True

                    lblFechaDesactivacion.Visible = True
                    lblDatoFecha.Visible = True
                Else
                    lblTipoFacturacion.Visible = False
                    cmbTipoFacturacion.Visible = False

                    lblFechaDesactivacion.Visible = False
                    lblDatoFecha.Visible = False
                End If
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.Close()
    End Sub

    Private Sub btnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSi.Click
        Try
            Dim iResp As Integer

            If sAccion = "A" Then
                If cmbTipoFacturacion.SelectedIndex = -1 Then
                    MessageBox.Show("Debe Seleccionar Tipo de Facturación.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbTipoFacturacion.Focus()
                    Exit Sub
                End If
            End If

            iResp = MessageBox.Show("¿Está Seguro de " & IIf(sAccion = "A", "Activar", "Desactivar") & " la Línea de Crédito?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If iResp = vbYes Then
                If cmbTipoFacturacion.SelectedValue Is Nothing Then
                    IdTipo_Facturacion = 0
                Else
                    IdTipo_Facturacion = cmbTipoFacturacion.SelectedValue
                End If

                Dim rst As DataTable
                rst = sp_upd_linea_credito()
                If rst.Rows(0).Item(0) = 0 Then
                    MessageBox.Show("La Línea de Crédito ha sido " & IIf(sAccion = "A", "Activada", "Desactivada"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Close()
                    FrmClientes.bActualizado = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub


    Public Function SP_Linea_Credito() As DataTable
        Try
            Dim obj As New dtoLineaCredito
            Return obj.Obtener_Linea_Credito(iSolicitud)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function sp_upd_linea_credito() As DataTable
        Try
            Dim obj As New dtoLineaCredito
            Return obj.upd_linea_credito(iSolicitud, iId, sAccion, IdTipo_Facturacion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class