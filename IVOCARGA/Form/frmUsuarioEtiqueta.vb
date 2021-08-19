Public Class frmUsuarioEtiqueta
    Public pb_cancelar As Boolean
    Public pl_idusuario_personal As Long

    Dim obj_general As New ClsLbTepsa.dtoGENERAL
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmUsuarioEtiqueta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Me.txtPasswor.Focus()
    End Sub

    Private Sub frmUsuarioEtiqueta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmUsuarioEtiqueta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            pb_cancelar = True
            Me.txtPasswor.Focus()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            valida_password()
            pb_cancelar = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancelar.Click
        pb_cancelar = True
        Me.Close()
    End Sub

    Sub valida_password()
        Dim li_retorno As Integer
        Dim ls_mensaje As String
        Try
            '
            If Me.txtLogin.Text = "" Then
                MessageBox.Show("Ingrese el Usuario.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtLogin.Focus()
                Exit Sub
            End If
            '
            If Me.txtPasswor.Text = "" Then
                MessageBox.Show("Ingrese el Password.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPasswor.Focus()
                Exit Sub
            End If
            ' Valida el usuario con su respectiva clave y recupera el id del usuario '            
            obj_general.login = Me.txtLogin.Text
            obj_general.password = Me.txtPasswor.Text
            'DataHelper
            obj_general.valida_usuario()
            '
            li_retorno = obj_general.retorno
            If li_retorno = 0 Then
                pl_idusuario_personal = obj_general.idusuario_personal
                Me.Close()
                Exit Sub
            End If
            ls_mensaje = obj_general.mensaje
            MessageBox.Show(ls_mensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            '
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))

    End Sub

    Private Sub txtPasswor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPasswor.KeyPress
        If Convert.ToInt32(e.KeyChar) = Keys.Enter Then
            btn_aceptar_Click(sender, e)
        End If
    End Sub
End Class