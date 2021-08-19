Public Class frmusuario_entrega
#Region "Varible Publica"
    Public pb_cancelar As Boolean
    Public pl_idusuario_personal As Long

#End Region
#Region "Variables"
    Dim obj_general As New ClsLbTepsa.dtoGENERAL
    Dim bIngreso As Boolean = False
    Dim blnAceptar As Boolean = False
    Public hnd As Long
#End Region
#Region "Evento Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'MyBase.OnPaint(e)
        'Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        'Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) And Me.txtPasswor.Focused = False Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"
    Private Sub frmusuario_entrega_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtPasswor.Focus()
    End Sub

    Private Sub frmusuario_entrega_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmusuario_entrega_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnAceptar Then
            pb_cancelar = True
        End If
    End Sub
    Private Sub frmusuario_entrega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            pb_cancelar = False
            Me.txtPasswor.Focus()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        valida_password()

    End Sub
    Private Sub Btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancelar.Click
        Try
            pb_cancelar = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub txtPasswor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPasswor.KeyDown

    End Sub
    Private Sub txtPasswor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPasswor.KeyPress
        'If e.KeyChar = Chr(13) Then            
        '    valida_password()
        'End If
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub valida_password()
        Dim li_retorno As Integer
        Dim ls_mensaje As String
        Try
            '
            If Me.txtLogin.Text = "" Then
                MessageBox.Show("Ingrese el Usuario", "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtLogin.Focus()
                Exit Sub
            End If
            '
            If Me.txtPasswor.Text.Trim = "" Then
                MessageBox.Show("Ingrese la Contraseña", "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPasswor.Focus()
                Exit Sub
            End If
            ' Valida el usuario con su respectiva clave y recupera el id del usuario '            
            obj_general.login = Me.txtLogin.Text
            obj_general.password = Me.txtPasswor.Text
            'Datahelper
            obj_general.valida_usuario()
            '
            li_retorno = obj_general.retorno
            If li_retorno = 0 Then
                pl_idusuario_personal = obj_general.idusuario_personal
                blnAceptar = True
                Me.Close()
                Exit Sub
            End If
            ls_mensaje = obj_general.mensaje
            MessageBox.Show(ls_mensaje, "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If li_retorno = 2 Then
                Me.txtLogin.Text = ""
                Me.txtPasswor.Text = ""
                Me.txtLogin.Focus()
                Exit Sub
            End If
            If li_retorno = 3 Then
                Me.txtPasswor.Text = ""
                Me.txtPasswor.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuario Entrega Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region

    Private Sub txtLogin_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLogin.TextChanged

    End Sub

    Private Sub txtPasswor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPasswor.TextChanged

    End Sub
End Class