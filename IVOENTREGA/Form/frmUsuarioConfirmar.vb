Public Class frmUsuarioConfirmar
    Public intLLamada As Integer = 0
    Dim blnSalir As Boolean

#Region "Propiedad"
    Private intUsuario As Integer
    Public Property IDUsuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property

    Private strUsuario As String
    Public Property Usuario() As String
        Get
            Return strUsuario
        End Get
        Set(ByVal value As String)
            strUsuario = value
        End Set
    End Property

    Private intResultado As Integer
    Public Property Resultado() As Integer
        Get
            Return intResultado
        End Get
        Set(ByVal value As Integer)
            intResultado = value
        End Set
    End Property


#End Region

    Private Sub frmUsuarioConfirmar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmUsuarioConfirmar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Validar()
    End Sub

    Sub Validar()
        Dim li_retorno As Integer
        Dim ls_mensaje As String
        Try
            '
            If Me.txtUsuario.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Usuario", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtUsuario.Text = ""
                Me.txtUsuario.Focus()
                blnSalir = False
                Exit Sub
            End If
            '
            If Me.txtContraseña.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Contraseña", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtContraseña.Text = ""
                Me.txtContraseña.Focus()
                blnSalir = False
                Exit Sub
            End If
            ' Valida el usuario con su respectiva clave y recupera el id del usuario '            
            Dim obj_general As New ClsLbTepsa.dtoGENERAL
            obj_general.login = Me.txtUsuario.Text
            obj_general.password = Me.txtContraseña.Text

            obj_general.valida_usuario(intLLamada)
            '
            li_retorno = obj_general.retorno
            Resultado = 0
            If li_retorno = 0 Then
                Resultado = 1
                IDUsuario = obj_general.idusuario_personal
                Usuario = obj_general.Usuario
                Exit Sub
            End If
            ls_mensaje = obj_general.mensaje
            MessageBox.Show(ls_mensaje, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If li_retorno = 2 Then
                Me.txtUsuario.Text = ""
                Me.txtContraseña.Text = ""
                Me.txtUsuario.Focus()
                blnSalir = False
                Exit Sub
            End If
            If li_retorno = 3 Then
                Me.txtContraseña.Text = ""
                Me.txtContraseña.Focus()
                blnSalir = False
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtContraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraseña.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub frmUsuarioConfirmar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.txtContraseña.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub
End Class