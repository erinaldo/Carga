Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Windows.Forms
'Imports Windows.Forms
Public Class frmLOGIN_USER
#Region "VARIABLES"
    Dim Utils As uUtils

    '    Dim IPComputer As IPAddress
    Public UserMane As String
    Public ComputerName As String
    Public IPHome As String
    Private Client As TcpClient
    Private PublicIP As String
    Private iContador_Accesos As Integer
    Public iCONTROL_VENTANA As Integer = 0
    '   Public Const IPAddress As String
    Public lee_focus As Boolean = True
#End Region
    Dim ObjPersona As New ClsLbTepsa.dtoPersona

    Private Sub frmLOGIN_USER_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me)
    End Sub

    Private Sub frmLOGIN_USER_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmLOGIN_USER_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        txtLogin.Focus()
    End Sub
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'txtLogin.Text = "login"
            'txtPasswor.Text = "sa"
            'PBImagen.Image = New Drawing.Bitmap("C:\icon\Titan.bmp")  Mod 12/10/2006
            PBImagen.Image = New Drawing.Bitmap("..\icon\Titan.bmp")
            If iCONTROL_VENTANA = 0 Then
                ModuUtil.IniciarImagenes()
                'Call ModConexion.InitConexion()
                '
                '22/10/2009 - Tepsa se comento por cambio de arquitectura (datahelper)
                'ModVOCONTROLUSUARIO.ListaUsuarios(1)
                '
                'Dim cn As New System.Data.OracleClient.OracleConnection("data source=tepsa; password=titan; user id=titan")
                'cn.Open()
                'Dim da As New System.Data.OracleClient.OracleDataAdapter("select * from t_guias_envio", cn)
                'Dim ds As New DataSet
                'da.Fill(ds, "f")
                'Me.DataGridView1.DataSource = ds.Tables("f")
            End If
            '
            'cnn.Close()
            'cnn.Open()
            '
            iContador_Accesos = 1
            ' 
            txtLogin.Focus()
            '

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me)

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public ReadOnly Property PublicIPAddress() As String
    Public Sub PIPAddressA()
        Try
            Dim pi As PropertyInfo = _
                          Client.GetStream.GetType.GetProperty( _
                          "Socket", BindingFlags.NonPublic Or BindingFlags.Instance)
            If Not pi Is Nothing Then
                PublicIP = pi.GetValue(Client.GetStream, _
                Nothing).RemoteEndPoint.ToString.Split(":")(0)
            End If
            ' Get the clients IP address using Client property            
            Dim ipend As Net.IPEndPoint = Client.Client.RemoteEndPoint
            If Not ipend Is Nothing Then
                PublicIP = ipend.Address.ToString
            End If
        Catch ex As System.ObjectDisposedException
            PublicIP = String.Empty
        Catch ex As SocketException
            PublicIP = String.Empty
        End Try
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        'Dim gradiente As New System.Drawing.Drawing2D.PathGradientBrush(rec, System.Drawing.Color.White, System.Drawing.SystemColors.Desktop, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRegion(System.Drawing.Drawing2D.PathGradientBrush(rec, System.Drawing.Color.White, System.Drawing.SystemColors.Desktop, System.Drawing.Drawing2D.LinearGradientMode.Vertical), New Drawing.Region(rec))        
    End Sub
    Function valida_version_clave()
        ObjPersona.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        ObjPersona.VERSION = V_VERSION
        '
        ObjPersona.SP_SI_PASSWORD_CAMBIADO()
        If Not ObjPersona.VERSION_ULTIMO = V_VERSION Then
            Dim a As New FrmActualiceVersion
            a.ShowDialog()
        End If
        If Not ObjPersona.PASSWORD_CAMBIADO = 1 Then
            Dim a As New FrmCambiarPasswordInicio
            a.ShowDialog()
        End If        
    End Function
    Private Sub btnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            '
            Control_Accesos()
            '
        Catch ex As Exception
            MsgBox("Usted no tiene acceso, cuenta inhabilitada", MsgBoxStyle.Critical, "Seguridad Sistema")
            'End
        End Try
    End Sub
    Private Sub Control_Accesos()
        Try
            If Windows.Forms.SystemInformation.Network = True Then
                If txtLogin.Text.Length > 0 And txtPasswor.Text.Length > 0 Then
                    dtoUSUARIOS.IP = Get_LocalIPAddress()
                    UserMane = Windows.Forms.SystemInformation.UserName
                    ComputerName = Windows.Forms.SystemInformation.ComputerName

                    dtoUSUARIOS.iLOGIN = IIf(txtLogin.Text.Length > 0, txtLogin.Text, "0")
                    dtoUSUARIOS.Password = IIf(txtPasswor.Text.Length > 0, txtPasswor.Text, "0")
                    iContador_Accesos = iContador_Accesos + 1
                    'Mod.15/10/2009 -->Omendoza - Pasando al datahelper -  
                    If fnINICIO_SESION() = True Then 'Carga los valores del usuario a un datatable 
                        Me.Hide()
                        If iCONTROL_VENTANA = 0 Then
                            valida_version_clave()
                            Me.Close()
                            'Dim objMenuintegrado As New Principal()
                            'objMenuintegrado.ShowDialog()
                        End If
                    Else
                        If iContador_Accesos > 4 Then
                            MsgBox("Después 4 intentos, su usuario no tiene acceso al sistema", MsgBoxStyle.Critical, "Seguridad Sistema")
                            iContador_Accesos = 0
                            End
                        End If
                        dtoUSUARIOS.Password = ""
                    End If
                Else
                    MsgBox("No puede Conectarse con valores Nulos", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                    iContador_Accesos = iContador_Accesos + 1
                    If iContador_Accesos > 4 Then
                        MsgBox("Lo Siento usted No tiene Acceso ", MsgBoxStyle.Critical, "Seguridad Sistema")
                        iContador_Accesos = 0
                        End
                    End If
                End If
            Else
                MsgBox("Error... usted no tiene RED Verifique su conexion, su cable , consulte con Sistemas ...", MsgBoxStyle.Critical, "Seguridad Sistema")
            End If
        Catch ex As Exception
            ' ex.ToString()
            'MsgBox("Error usuario desconocido", MsgBoxStyle.Information, "Seguridad Sistema")  'Tepsa 
            MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            End
        Catch
            MsgBox("Invalid Regular Expression")
            Exit Sub
        End Try
    End Sub
    Private Sub txtPasswor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPasswor.KeyDown
        Try
            If e.KeyData = Windows.Forms.Keys.Enter Then
                Control_Accesos()
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmLOGIN_USER_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        txtLogin.Focus()
    End Sub
    Private Sub frmLOGIN_USER_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If lee_focus Then
            txtLogin.Focus()
        End If
    End Sub
    Private Sub txtLogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
        lee_focus = False
    End Sub

    Private Sub Labversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Labversion.Click

    End Sub
End Class