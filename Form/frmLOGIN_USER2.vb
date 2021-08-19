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
    Dim coll_Lista_Agencias As New Collection
    Private Client As TcpClient
    Private PublicIP As String
    Private iContador_Accesos As Integer
    Public iCONTROL_VENTANA As Integer = 0
    '   Public Const IPAddress As String
    Public lee_focus As Boolean = True
    Dim bOk As Boolean
#End Region
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim dtAgencias As DataTable '-->Agregado 25/01/2013

    Private Sub frmLOGIN_USER_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtLogin.Focus()
    End Sub

    Private Sub frmLOGIN_USER_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
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

            '

            Me.lblPassword.Top = 57
            Me.txtPasswor.Top = 57

            Me.lblRol.Top = 97
            Me.CboRol.Top = 97

            txtLogin.Focus()

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public ReadOnly Property PublicIPAddress() As String
    Public Sub PIPAddressA()
        Try
            Dim pi As PropertyInfo = Client.GetStream.GetType.GetProperty("Socket", BindingFlags.NonPublic Or BindingFlags.Instance)
            If Not pi Is Nothing Then
                PublicIP = pi.GetValue(Client.GetStream, Nothing).RemoteEndPoint.ToString.Split(":")(0)
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
            Static bEntra As Boolean
            If CboRol.Items.Count = 0 Then
                bEntra = False
            Else
                bEntra = True
            End If
            bOk = True

            Control_Accesos()

            If Not bOk Then
                If Me.txtLogin.Text.Trim.Length = 0 Then
                    Me.txtLogin.Focus()
                    Return
                End If

                If Me.txtPasswor.Text.Trim.Length = 0 Then
                    Me.txtPasswor.Focus()
                    Return
                End If
            End If

            If CboRol.SelectedIndex = -1 And CboRol.Enabled Then
                MessageBox.Show("Debe seleccionar un Rol.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If CboRol.Enabled Then
                    CboRol.Focus()
                Else
                    txtLogin.Focus()
                End If
                Return
            End If

            If bEntra Then
                If CboRol.SelectedIndex > -1 Then
                    dtoUSUARIOS.IdRol = CboRol.SelectedValue
                    G_Rol = dtoUSUARIOS.IdRol
                    G_Rol_descripcion = CboRol.Text
                    '
                    If cboAgencia.SelectedIndex > -1 Then
                        dtoUSUARIOS.iIDAGENCIAS = Int(coll_Lista_Agencias(cboAgencia.SelectedIndex + 1))

                        '-->Obtiene el codigo de la agencia asociada al sisvyr
                        For Each row As DataRow In dtAgencias.Rows
                            If (row("IDAGENCIAS") = dtoUSUARIOS.iIDAGENCIAS) Then
                                dtoUSUARIOS.codAgenciaSisvyr = row("Cod_Age_Sisvyr")
                                Exit For
                            End If
                        Next
                    End If
                    dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
                    dtoUSUARIOS.IdAgenciaReal = dtoUSUARIOS.iIDAGENCIAS
                    '02/09/2010 - Para recuperar la ciudad 
                    dtoUSUARIOS.m_idciudad = fnGet_idCiudad(dtoUSUARIOS.m_iIdAgencia) 'fnGet_Ciudad --> (Modutil) 
                    dtoUSUARIOS.IdUnidadAgenciaReal = dtoUSUARIOS.m_idciudad
                    '
                    dtoUSUARIOS.ciudad = dtoUSUARIOS.m_idciudad
                    dtoUSUARIOS.agencia = dtoUSUARIOS.iIDAGENCIAS

                    '*************************
                    dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
                    dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
                    'dtoUSUARIOS.m_iOficinaVenta = fnGet_OFICINAVENTA(dtoUSUARIOS.m_iIdAgencia) ' 

                    dtoUSUARIOS.Portavalor = fnGetPortavalor(dtoUSUARIOS.m_iIdAgencia)
                    '*************************
                    '
                    Acepta()

                    Dim LFA As New List(Of Form)
                    LFA.Clear()
                    For Each frm As Form In Application.OpenForms
                        If frm.Name.ToUpper <> "PRINCIPAL" And frm.Name.ToUpper <> "FRMLOGIN_USER" Then
                            LFA.Add(frm)
                        End If
                    Next
                    Dim X As Integer
                    For X = 0 To LFA.Count - 1
                        LFA(X).Close()
                    Next

                End If
            Else
                CboRol.Focus()
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad Sistema")
            'End
        End Try
    End Sub

    Private Sub Control_Accesos()
        Try
            If Windows.Forms.SystemInformation.Network = True Then
                If txtLogin.Text.Length > 0 And txtPasswor.Text.Length > 0 Then
                    dtoUSUARIOS.IP = Get_LocalIPAddress()
                    dtoUSUARIOS.IPReal = dtoUSUARIOS.IP
                    'dtoUSUARIOS.IP = "10.1.1.2"
                    'dtoUSUARIOS.IP = "192.168.50.41" '
                    'dtoUSUARIOS.IP = "192.168.50.30" 'jsalas
                    'dtoUSUARIOS.IP = "192.168.50.107" 'cbravo
                    'dtoUSUARIOS.IP = "192.168.50.202" 'narce
                    dtoUSUARIOS.IP = "192.168.50.47" 'cusco

                    '
                    UserMane = Windows.Forms.SystemInformation.UserName
                    ComputerName = Windows.Forms.SystemInformation.ComputerName

                    dtoUSUARIOS.iLOGIN = IIf(txtLogin.Text.Length > 0, txtLogin.Text, "0")
                    dtoUSUARIOS.Password = IIf(txtPasswor.Text.Length > 0, txtPasswor.Text, "0")
                    iContador_Accesos = iContador_Accesos + 1
                    'Mod.15/10/2009 -->Omendoza - Pasando al datahelper -  

                    'hlamas 09-12-2013 temporal
                    'dtoUSUARIOS.IP = Get_LocalIPAddress()
                    'ActualizaVersionIP(dtoUSUARIOS.IP)

                    If fnINICIO_SESION() = True Then 'Carga los valores del usuario a un datatable 
                        If dtoUSUARIOS.TipoIp = 1 Then
                            lblAgencia.Visible = False
                            cboAgencia.Visible = False
                        Else
                            Me.lblPassword.Top = 47
                            Me.txtPasswor.Top = 47

                            Me.lblRol.Top = 77
                            Me.CboRol.Top = 77

                            lblAgencia.Visible = True
                            cboAgencia.Visible = True
                        End If
                        Me.CboRol.Enabled = True
                        If CboRol.Enabled And CboRol.Items.Count = 0 Then
                            Dim obj As New Acceso
                            Dim dt As DataTable = obj.ListarRol(dtoUSUARIOS.IdLogin)
                            If dt.Rows.Count < 1 Then
                                MsgBox("El usuario " + dtoUSUARIOS.iLOGIN + " no tiene nigún rol asignado", MsgBoxStyle.Critical, "Seguridad Sistema")
                                iContador_Accesos = 0
                                End
                            End If
                            '
                            Dim iRolDefecto As Integer = dtoUSUARIOS.RolDefecto

                            CargarCombo(CboRol, dt, "rol2", "rol1", iRolDefecto)
                            If CboRol.SelectedIndex = -1 Then CboRol.SelectedIndex = 0
                            Me.CboRol.Focus()
                        End If

                        If dtoUSUARIOS.TipoIp = 2 Then
                            Me.cboAgencia.Enabled = True
                            If Me.cboAgencia.Items.Count = 0 Then
                                'Dim dt As DataTable = ObjVentaPasaje.fnGetAgencias()
                                dtAgencias = ObjVentaPasaje.fnGetAgencias()
                                ModuUtil.LlenarCombo2(dtAgencias, cboAgencia, coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
                            End If
                        Else
                            Me.cboAgencia.SelectedIndex = -1
                            Me.cboAgencia.Enabled = False

                            dtAgencias = ObjVentaPasaje.fnGetAgencias()
                            '-->Obtiene el codigo de la agencia asociada al sisvyr
                            For Each row As DataRow In dtAgencias.Rows
                                If (row("IDAGENCIAS") = dtoUSUARIOS.iIDAGENCIAS) Then
                                    dtoUSUARIOS.codAgenciaSisvyr = row("Cod_Age_Sisvyr")
                                    Exit For
                                End If
                            Next
                            'Me.cboAgencia.Focus()
                        End If
                        'Me.Hide()
                        'If iCONTROL_VENTANA = 0 Then
                        '    valida_version_clave()
                        '    Me.Close()
                        'End If
                    Else
                        If iContador_Accesos > 4 Then
                            MsgBox("Después 4 intentos, su usuario no tiene acceso al sistema", MsgBoxStyle.Critical, "Seguridad Sistema")
                            iContador_Accesos = 0
                            End
                        End If
                        dtoUSUARIOS.Password = ""
                    End If
                Else
                    MsgBox("Debe Ingresar Usuario y Contraseña.", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                    bOk = False
                    iContador_Accesos = iContador_Accesos + 1
                    If iContador_Accesos > 4 Then
                        MsgBox("Ud. no tiene Acceso.", MsgBoxStyle.Critical, "Seguridad Sistema")
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
            Me.CboRol.Enabled = False
            Me.CboRol.Items.Clear()
            Me.CboRol.SelectedIndex = -1
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

    Private Sub txtPasswor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPasswor.Enter
        Me.txtPasswor.SelectAll()
    End Sub
    Private Sub txtPasswor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPasswor.KeyDown
        'Try
        'If e.KeyData = Windows.Forms.Keys.Enter Then
        '    Control_Accesos()
        '    If Me.CboRol.Enabled Then
        '        'Me.CboRol.Focus()
        '    Else
        '        'Me.btnAceptar.Focus()
        '    End If
        'End If
        'Catch ex As Exception
        'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub
    Private Sub frmLOGIN_USER_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        txtLogin.Focus()
    End Sub
    Private Sub frmLOGIN_USER_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If lee_focus Then
            txtLogin.Focus()
        End If
    End Sub

    Private Sub txtLogin_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogin.Enter
        Me.txtLogin.SelectAll()
    End Sub

    Private Sub txtLogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLogin.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtPasswor.Focus()
        End If
    End Sub
    Private Sub txtLogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
        lee_focus = False
        Me.txtPasswor.Text = ""
        Me.CboRol.Enabled = False

        Me.CboRol.DataSource = Nothing
        Me.CboRol.SelectedIndex = -1

        Me.cboAgencia.DataSource = Nothing
        Me.lblAgencia.Visible = False
        Me.cboAgencia.Visible = False

        Me.lblPassword.Top = 57
        Me.txtPasswor.Top = 57

        Me.lblRol.Top = 97
        Me.CboRol.Top = 97
    End Sub

    Private Sub CboRol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboRol.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Me.cboAgencia.Visible Then
                Me.cboAgencia.Focus()
            Else
                Dim ee As EventArgs
                Me.btnAceptar_Click_1(sender, ee)
            End If
        End If
    End Sub
    Sub Acepta()
        Me.Hide()
        If iCONTROL_VENTANA = 0 Then
            valida_version_clave()
            Me.Close()
        End If
    End Sub

    Private Sub CboRol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRol.SelectedIndexChanged

    End Sub

    Private Sub cboAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAgencia.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dim ee As New EventArgs
            Me.btnAceptar_Click_1(sender, ee)
        End If
    End Sub

    Private Sub txtPasswor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPasswor.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            Control_Accesos()
            If Me.CboRol.Enabled Then
                Me.CboRol.Focus()
            End If
        End If
    End Sub

    Private Sub txtPasswor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPasswor.TextChanged

    End Sub

    Private Sub Labversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Labversion.Click

    End Sub
End Class