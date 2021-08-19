Public Class Frm_configura_cliente
#Region "Publicas"
    Public pl_idusuario_personal As Long
#End Region
#Region "Variables"
    Dim dto_clientes As New ClsLbTepsa.dto_clientes_new
    Dim pb_cambio As Boolean = False
    Dim pb_no_lee As Boolean = True
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub Frm_configura_cliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub Frm_configura_cliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ldt_configura_cliente As New DataTable
            '22/07/2009 - Recupera los datos a modific                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ar del cliente 
            dto_clientes.idpersona = pl_idusuario_personal
            'datahelper
            'ldt_configura_cliente = dto_clientes.sp_get_configurar_clte(cnn)
            ldt_configura_cliente = dto_clientes.sp_get_configurar_clte()
            '---
            pb_no_lee = False
            '---
            If IsDBNull(ldt_configura_cliente.Rows(0).Item(0)) = True Then
                Me.txt_login.Text = ""
            Else
                Me.txt_login.Text = CType(ldt_configura_cliente.Rows(0).Item(0), String) ' Recupera Login
            End If
            If IsDBNull(ldt_configura_cliente.Rows(0).Item(1)) = True Then
                Me.txt_password.Text = ""
            Else
                Me.txt_password.Text = CType(ldt_configura_cliente.Rows(0).Item(1), String) ' Recupera Login
            End If
            If IsDBNull(ldt_configura_cliente.Rows(0).Item(2)) = True Then
                Me.txt_nro_digitos.Text = 3 ' Si no encuentra valor por defecto será 3 
            Else
                Me.txt_nro_digitos.Text = CType(ldt_configura_cliente.Rows(0).Item(2), String) ' Recupera Nro Digitos
            End If
            pb_no_lee = True

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            Dim ls_mensaje As String
            If pb_cambio = True Then
                If Me.txt_login.Text <> "" Then
                    If Me.txt_password.Text = "" Then
                        MsgBox("Falta ingresar la clave para el cliente", MsgBoxStyle.Information, "Configuración del Cliente")
                        Me.txt_password.Focus()
                        Exit Sub
                    End If
                End If
                If Me.txt_password.Text <> "" Then
                    If Me.txt_login.Text = "" Then
                        MsgBox("Falta ingresar el usuario para el cliente", MsgBoxStyle.Information, "Configuración del Cliente")
                        Me.txt_login.Focus()
                        Exit Sub
                    End If
                End If
                If CType(Me.txt_nro_digitos.Text, Long) = 0 Or Me.txt_nro_digitos.Text = "" Then
                    MsgBox("El número de digitos debe tener un valor diferente de 0 y no debe estar en blanco", MsgBoxStyle.Information, "Configuración del Cliente")
                    Me.txt_nro_digitos.Focus()
                    Exit Sub
                End If
                Dim ldt_configura_cliente As New DataTable
                '22/07/2009 - Actualiza los datos a modificar del cliente 
                dto_clientes.idpersona = pl_idusuario_personal
                dto_clientes.login = Me.txt_login.Text
                dto_clientes.password = Me.txt_password.Text
                dto_clientes.nro_digito_serie = CType(Me.txt_nro_digitos.Text, Long)
                '
                'datahelper
                'ldt_configura_cliente = dto_clientes.sf_actualiza_configura_clte(cnn)
                ldt_configura_cliente = dto_clientes.sf_actualiza_configura_clte()
                If CType(ldt_configura_cliente.Rows(0).Item(0), Long) = 0 Then
                    ls_mensaje = ldt_configura_cliente.Rows(0).Item(1)
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Configuración del Cliente")
                Else
                    ls_mensaje = ldt_configura_cliente.Rows(0).Item(1)
                    MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Configuración del Cliente")
                    Exit Sub
                End If

            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub txt_login_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_login.TextChanged
        If pb_no_lee = True Then
            pb_cambio = True
        End If
    End Sub
    Private Sub txt_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password.TextChanged
        If pb_no_lee = True Then
            pb_cambio = True
        End If
    End Sub
    Private Sub txt_nro_digitos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_digitos.TextChanged
        If pb_no_lee = True Then
            pb_cambio = True
        End If
    End Sub
#End Region
#Region "Funciones"
#End Region
#Region "Procedimientos"
#End Region

    
    

    
    
    


End Class