Public Class frmcargofactura
    Public brefrescar As Boolean = False
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmcargofactura_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmcargofactura_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmcargofactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.DTP_fecha_cargo.Value = dtoUSUARIOS.m_sFecha
            Me.DTP_fecha_cargo.Focus()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        fn_grabar()
    End Sub
    Sub fn_grabar()
        Dim smensaje As String
        Dim lnromensaje As Long
        ' Validar los campos que son principales         
        Dim MyObligatorios As Object() = {Me.txtmensajero}
        If Funciones.Validaciones(MyObligatorios) = 0 Then
            Objfacturacargo.sidpersona = Me.txtidpersona.Text
            Objfacturacargo.sidfactura = Me.txtidfactura.Text
            Objfacturacargo.sfecha_cargo = CType(Me.DTP_fecha_cargo.Value, String)
            Objfacturacargo.smensajero = Me.txtmensajero.Text
            Objfacturacargo.sidusuario = dtoUSUARIOS.IdLogin
            If Objfacturacargo.fn_actualiza_fecha_cargo() Then
                lnromensaje = Objfacturacargo.lcodoracle
                smensaje = Objfacturacargo.smensaje
                If lnromensaje <> 0 Then
                    MsgBox(smensaje, MsgBoxStyle.Exclamation, "Factura Cargo")
                    Exit Sub
                Else
                    brefrescar = True
                    Me.Close()
                End If
            End If
        End If
    End Sub


End Class