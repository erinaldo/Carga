Public Class frmUsuarioValor
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

    Private intUnidad As Integer
    Public Property Unidad() As Integer
        Get
            Return intUnidad
        End Get
        Set(ByVal value As Integer)
            intUnidad = value
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
        Validar(2)
    End Sub

    Function Validar(ByVal opcion As Integer) As Boolean
        Dim li_retorno As Integer
        Dim ls_mensaje As String
        Try
            '
            If Me.txtUsuario.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Usuario", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtUsuario.Text = ""
                Me.txtUsuario.Focus()
                blnSalir = False
                Return blnSalir
            End If
            '
            If Me.txtContraseña.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Contraseña", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtContraseña.Text = ""
                Me.txtContraseña.Focus()
                blnSalir = False
                Return blnSalir
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
                IDUsuario = obj_general.idusuario_personal
                Usuario = obj_general.Usuario
                Unidad = obj_general.unidad
                If opcion = 1 Then
                    blnSalir = True
                    Return blnSalir
                Else
                    If Me.cboRol.SelectedValue > 0 Then
                        Resultado = 1
                        blnSalir = True
                    Else
                        MessageBox.Show("El usuario " & strUsuario & " no tiene ningún rol asociado", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtUsuario.Focus()
                        blnSalir = False
                    End If
                    Return blnSalir
                End If
            End If
            ls_mensaje = obj_general.mensaje
            MessageBox.Show(ls_mensaje, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If li_retorno = 2 Then
                Me.txtUsuario.Text = ""
                Me.txtContraseña.Text = ""
                Me.txtUsuario.Focus()
                blnSalir = False
                Return blnSalir
            End If
            If li_retorno = 3 Then
                Me.txtContraseña.Text = ""
                Me.txtContraseña.Focus()
                blnSalir = False
                Return blnSalir
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtContraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraseña.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Validar(1) Then
                Dim obj As New Acceso
                Dim dt As DataTable = obj.ListarRol(intUsuario)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("El usuario " & strUsuario & " no tiene ningún rol asignado", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtUsuario.Focus()
                    Me.cboRol.Enabled = False
                    blnSalir = False
                    Return
                End If
                Me.cboRol.Enabled = True
                CargarCombo(cboRol, dt, "rol2", "rol1", 0)
                If cboRol.SelectedIndex = -1 Then cboRol.SelectedIndex = 0
                Me.cboRol.Focus()
            End If
        End If
    End Sub

    Private Sub frmUsuarioConfirmar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.txtUsuario.Text.Trim.Length > 0 Then
            Me.txtContraseña.Focus()
        Else
            Me.txtUsuario.Focus()
        End If
    End Sub

    Private Sub cboRol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRol.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        End If
    End Sub
End Class