Imports Microsoft.Win32
Public Class frmGoogleMaps
    Dim blnInicio As Boolean
    Dim Url2 As String
    Dim blnAceptar As Boolean = False

    Private strDireccion As String
    Public Property Direccion() As String
        Get
            Return strDireccion
        End Get
        Set(ByVal value As String)
            strDireccion = value
        End Set
    End Property

    Private strUrl As String
    Public Property Url() As String
        Get
            Return strUrl
        End Get
        Set(ByVal value As String)
            strUrl = value
        End Set
    End Property

    Private sLatitud As String
    Public Property Latitud() As String
        Get
            Return sLatitud
        End Get
        Set(ByVal value As String)
            sLatitud = value
        End Set
    End Property

    Private strLongitud As String
    Public Property Longitud() As String
        Get
            Return strLongitud
        End Get
        Set(ByVal value As String)
            strLongitud = value
        End Set
    End Property

    Private Sub frmGoogleMaps_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blnInicio = True
        Me.Text = "Google Maps - " & Direccion

        setRegisterForWebBrowser()
        web.ScriptErrorsSuppressed = True

        If Url.Trim.Length = 0 Then
            web.Navigate("https://www.google.com/maps")
            Url2 = "https://www.google.com/maps"
        Else
            web.Navigate(Url.Trim)
            Url2 = Url.Trim
        End If
    End Sub

    Private Sub setRegisterForWebBrowser()
        Dim appName = Process.GetCurrentProcess().ProcessName + ".exe"
        SetIE8KeyforWebBrowserControl(appName)
    End Sub

    Private Sub SetIE8KeyforWebBrowserControl(ByVal appName As String)
        'ref:    http://stackoverflow.com/questions/17922308/use-latest-version-of-ie-in-webbrowser-control
        Dim Regkey As RegistryKey = Nothing
        Dim lgValue As Long '= 11001

        If web.Version.Major >= 10 Then
            lgValue = web.Version.Major.ToString + "001"
        ElseIf web.Version.Major >= 8 Then
            lgValue = IIf(web.Version.Major = 8, "8888", "9999")
        Else
            lgValue = "7000"
        End If

        Dim strValue As Long = lgValue.ToString()
        Try
            'For 64 bit Machine 
            'If (Environment.Is64BitOperatingSystem) Then
            'Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", True)
            'Else  'For 32 bit Machine 
            'Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", True)
            'End If
            Regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", True)

            'If the path Is Not correct Or 
            'If user't have priviledges to access registry 
            If (Regkey Is Nothing) Then
                MessageBox.Show("La ruta es incorrecta o no tiene privilegios. El registro de la aplicación Google Maps ha fallado")
                Return
            End If

            Dim FindAppkey As String = Convert.ToString(Regkey.GetValue(appName))
            'Check if key Is already present
            If FindAppkey.Trim.Length > 0 Then
                If (FindAppkey = strValue) Then
                    'MessageBox.Show("ya está actualizado")
                    Regkey.Close()
                    Return
                End If
            End If

            'If key Is Not present add the key , Kev value 8000-Decimal 
            If (String.IsNullOrEmpty(FindAppkey)) Then
                ' Regkey.SetValue(appName, BitConverter.GetBytes(&H1F40), RegistryValueKind.DWord)
                Regkey.SetValue(appName, lgValue, RegistryValueKind.DWord)

                'check for the key after adding 
                FindAppkey = Convert.ToString(Regkey.GetValue(appName))
            End If

            If (FindAppkey = strValue) Then
                'MessageBox.Show("Registre de l'application appliquée avec succès")
            Else
                MessageBox.Show("Debe registrar una versión mas actual del navegador" + FindAppkey)
            End If
        Catch ex As Exception
            MessageBox.Show("El registro de la aplicación Google Maps ha fallado")
            MessageBox.Show(ex.Message)

        Finally
            'Close the Registry 
            If (Not Regkey Is Nothing) Then
                Regkey.Close()
            End If
        End Try
    End Sub

    Private Sub web_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles web.DocumentCompleted
        blnInicio = False
    End Sub

    Private Sub web_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles web.Navigated
        Dim s As String = web.Url().ToString
        Dim posicion As Integer = s.IndexOf("@")
        Dim m() As String
        If posicion > -1 Then
            Dim r As String = s.Substring(posicion + 1)
            Dim c() As String = r.Split(",")
            ReDim m(c.Length - 2)
            For i As Integer = 0 To c.Length - 2
                m(i) = c(i)
            Next
            If Not blnInicio Then
                Url = s
                Latitud = m(0)
                Longitud = m(1)
                'Me.Text = "Latitud:" & m(0) & ",Longitud:" & m(1) & "    " & e.Url.ToString
            Else
                Url = ""
                Latitud = ""
                Longitud = ""
                'Me.Text = e.Url.ToString
            End If
        Else
            'Me.Text = e.Url.ToString
            Url = ""
            Latitud = ""
            Longitud = ""
        End If

        Me.toolUrl.Text = e.Url.ToString
        Me.toolLatitud.Text = Latitud
        Me.toolLongitud.Text = Longitud
    End Sub

    Private Sub toolInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolInicio.Click
        'web.Navigate("https://www.google.com/maps")
        web.Navigate(Url2)
    End Sub

    Private Sub toolActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolActualizar.Click
        web.Refresh()
    End Sub

    Private Sub toolAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAtras.Click
        web.GoBack()
    End Sub

    Private Sub toolAdelante_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolAdelante.Click
        web.GoForward()
    End Sub

    Private Sub toolAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAceptar.Click
        If Latitud.Trim.Length = 0 Or Longitud.Trim.Length = 0 Then
            MessageBox.Show("Ubique la Dirección en el Mapa", "Google Maps", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        blnAceptar = True
        Close()
    End Sub

    Private Sub toolCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCancelar.Click
        Close()
    End Sub

    Private Sub frmGoogleMaps_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnAceptar Then
            Url = ""
            Latitud = ""
            Longitud = ""
        End If
        web.Dispose()
        web = Nothing
        System.GC.Collect(2, GCCollectionMode.Forced)
        System.GC.WaitForPendingFinalizers()
    End Sub
End Class