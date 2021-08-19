Imports INTEGRACION_LN
Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Web
Imports System.Data.Odbc
Imports Renci.SshNet
Imports Renci.SshNet.Sftp

Public Class Principal
    WithEvents btn As System.Windows.Forms.Button

    Dim cadena15 As String
    Dim abc As Cls_Utilitarios

    Private Sub AgenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Principal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ListarAgencia()
        Dim ctl As Control
        Dim ctlMDI As MdiClient
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
        With Me.MenuStrip1
            .AllowMerge = False
            .MdiWindowListItem = VentanaToolStripMenuItem
        End With

        Dim cadena_conexion As String = "data source=" + rptservice + "; user id=titan; password=titan"

        ''Obtener Usuario de Red
        'S_InicializaDatosUsuario()
        '
        '22-10-2009 Se comento la cadena de conexión 
        '
        'cnn = New System.Data.OracleClient.OracleConnection(cadena_conexion) '-- Tepsa  
        'cnn.Open()
        Try
            '01/09/2010 
            'Shell("pc.bat", AppWinStyle.Hide)
            '  
            Dim ObjFrm As New frmLOGIN_USER
            'ObjFrm.ShowDialog()
            'Acceso.Asignar(ObjFrm)
            'If Acceso.TieneAcceso(G_Rol, G_Fila) Then

            ObjFrm.txtLogin.Text = "hlamas"
            ObjFrm.txtPasswor.Text = "hlamas"

            'ObjFrm.txtLogin.Text = "ccachi"
            'ObjFrm.txtPasswor.Text = "5"

            'ObjFrm.txtLogin.Text = "ogonzalez"
            'ObjFrm.txtPasswor.Text = "g1"

            'ObjFrm.txtLogin.Text = "lgarcia"
            'ObjFrm.txtPasswor.Text = "Lgr261273"

            'ObjFrm.txtLogin.Text = "sciccia"
            'ObjFrm.txtPasswor.Text = "Franc0"

            'ObjFrm.txtLogin.Text = "gwest"
            'ObjFrm.txtPasswor.Text = "160416"

            'ObjFrm.txtLogin.Text = "acampos"
            'ObjFrm.txtPasswor.Text = "2019"

            'ObjFrm.txtLogin.Text = "portiz"
            'ObjFrm.txtPasswor.Text = "poa"

            'ObjFrm.txtLogin.Text = "krodriguez"
            'ObjFrm.txtPasswor.Text = "23"

            'ObjFrm.txtLogin.Text = "kvelasquez"
            'ObjFrm.txtPasswor.Text = "kvelasquez"

            'ObjFrm.txtLogin.Text = "macosta"
            'ObjFrm.txtPasswor.Text = "140216"

            'ObjFrm.txtLogin.Text = "jmuschi"
            'ObjFrm.txtPasswor.Text = "Franc0"

            'ObjFrm.txtLogin.Text = "ocarga"
            'ObjFrm.txtPasswor.Text = "x"

            'ObjFrm.txtLogin.Text = "eluna"
            'ObjFrm.txtPasswor.Text = "edumate"

            'ObjFrm.txtLogin.Text = "jleon"
            'ObjFrm.txtPasswor.Text = "Asesor002"

            'ObjFrm.txtLogin.Text = "acampos"
            'ObjFrm.txtPasswor.Text = "2019"

            ObjFrm.ShowDialog()
            ObjFrm.txtLogin.Focus()
            'Me.Text = "SISTEMA DE PRODUCCION TITAN  USUARIO [ " & dtoUSUARIOS.iLOGIN & " ] FECjHA: " & dtoUSUARIOS.m_sFecha & "  SERVIDOR : [ " & fnGetHOST_SERVIDOR() & " ]  IP LOCAL :" & dtoUSUARIOS.IP
            Me.Text = "SISTEMA DE PRODUCCION JOTASYS  USUARIO [" & dtoUSUARIOS.iLOGIN & "] ROL [" & G_Rol_descripcion & "] FECHA: " & dtoUSUARIOS.m_sFecha & "  IP LOCAL :" & dtoUSUARIOS.IP

            'pyme
            'Me.Text = "PYME-SISTEMA DE PRODUCCION TITAN  USUARIO [" & dtoUSUARIOS.iLOGIN & "] ROL [" & G_Rol_descripcion & "] FECHA: " & dtoUSUARIOS.m_sFecha & "  SERVIDOR : [ " & fnGetHOST_SERVIDOR() & " ]  IP LOCAL :" & dtoUSUARIOS.IP
            'Else
            'MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            '
            dtoUSUARIOS.IP = Get_LocalIPAddress()
            dtoUSUARIOS.IP = "192.168.50.47"

            ActualizaVersionIP(dtoUSUARIOS.IP)
            'hlamas 02-02-2016
            Dim dt As DataTable = ModuUtil.ObtenerInfoIP(dtoUSUARIOS.IP)
            dtoUSUARIOS.FormatoBoleta = dt.Rows(0).Item(0)
            dtoUSUARIOS.huella = dt.Rows(0).Item(1)
            dtoUSUARIOS.win = IIf(Environment.Is64BitProcess, 2, 1)

            If dtoUSUARIOS.IP = "192.168.50.218" Or dtoUSUARIOS.IP = "192.168.50.213" Or dtoUSUARIOS.IP = "192.168.50.74" Or dtoUSUARIOS.IP = "192.168.50.75" Then
                EntregaCargoToolStripMenuItem.Visible = False
            End If

            ObjFrm = Nothing

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub RutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaToolStripMenuItem1.Click
        Try
            Dim frm As New FrmRutas
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Ruta"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub MinimizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizarToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.WindowState = FormWindowState.Minimized
        Next
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub

    Private Sub OrganizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizarToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CascadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadaToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub HorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub VerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub ClienteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteToolStripMenuItem1.Click
        Try
            Dim frm As FrmClientes = New FrmClientes
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Cliente"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub AsociacionGuíaEnvioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsociacionGuíaEnvioToolStripMenuItem.Click
        Try
            Dim frm As FrmAsociacionGuiasEnvio = New FrmAsociacionGuiasEnvio
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Asociación Guía Envío"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub LíneaCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LíneaCréditoToolStripMenuItem.Click
        Try
            Dim frm As FrmAprobacionLineaCredito = New FrmAprobacionLineaCredito
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Aprobación de Línea de Crédito"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.WindowState = FormWindowState.Normal
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub TarifarioSubCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifarioSubCuentaToolStripMenuItem.Click
        Try
            'Revisado y Modificado por Diego Zegarra T. 12/07/2013'
            Dim frm As FrmTarifasSubCuenta = New FrmTarifasSubCuenta
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try

    End Sub

    Private Sub ClientePasajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientePasajeToolStripMenuItem.Click
        Try
            Dim frm As FrmClientesPasajes = New FrmClientesPasajes
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub CargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargaToolStripMenuItem.Click
        Try
            Dim frm As New FrmTarifaCarga
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifario Carga"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub PasajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasajeToolStripMenuItem.Click
        Try
            Dim frm As New FrmTarifaPasaje
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifario Pasaje"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ItinerarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItinerarioToolStripMenuItem.Click
        Try
            Dim Frm As New FrmItinerarios
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Itinerario"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub HorarioSalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorarioSalidaToolStripMenuItem.Click
        Try
            Dim Frm As New Frmhorariosalida
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Horario Salida"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub SalidasBusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidasBusToolStripMenuItem.Click
        Try
            Dim Frm As New frmsalidavehiculo
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Salida Bus"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub PaísToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub DepartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub ProvinciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub DistritoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub CiudadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarUsuarioToolStripMenuItem.Click
        Try
            Dim a As New frmLOGIN_USER()
            a.iCONTROL_VENTANA = 1
            a.ShowDialog()
            a.txtLogin.Focus()
            Me.Text = ""
            'Me.Text = "SISTEMA DE PRODUCCION TITAN  USUARIO [ " & dtoUSUARIOS.iLOGIN & " ] FECHA: " & dtoUSUARIOS.m_sFecha & "  SERVIDOR : [ " & fnGetHOST_SERVIDOR() & " ]  IP LOCAL :" & dtoUSUARIOS.IP
            Me.Text = "SISTEMA DE PRODUCCION TITAN  USUARIO [" & dtoUSUARIOS.iLOGIN & "] ROL [" & G_Rol_descripcion & "] FECHA: " & dtoUSUARIOS.m_sFecha & "  SERVIDOR : [ " & fnGetHOST_SERVIDOR() & " ]  IP LOCAL :" & dtoUSUARIOS.IP
            a = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub CambiarPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarPasswordToolStripMenuItem.Click
        Try
            Dim a As New FrmCambiarPassword
            a.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub CpuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub SolicitudRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudRecojoToolStripMenuItem.Click
        Try
            Dim Frm As New FrmSolicitudRecojo
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Solicitud Recojo"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ConsultaRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaRecojoToolStripMenuItem.Click
        Try
            Dim Frm As New FrmConsuRecojos
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Consulta Recojo"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub RutaEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaEntregaToolStripMenuItem.Click
        Try
            Dim Frm As New frmrutasrecojoentrega
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Rutas Entrega"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub RecojoAcordadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecojoAcordadoToolStripMenuItem.Click
        Try
            Dim Frm As New Frmrecojopactado
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Recojo Acordado"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub UnidadTransporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadTransporteToolStripMenuItem.Click
        Try
            Dim Frm As New Frmunidadtransporte
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Unidad Transporte"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GuíasEnvíoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíasEnvíoToolStripMenuItem.Click
        Dim frm As New FrmGuia
        frm.StartPosition = FormStartPosition.Manual
        frm.MaximizeBox = False
        frm.ControlBox = True
        frm.MdiParent = Me
        frm.Show()
        'Acceso.Asignar(frm)
        'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '    frm.MdiParent = Me
        '    frm.hnd = Hnd
        '    frm.Show()
        'Else
        '    MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub RecepciónGuíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónGuíasToolStripMenuItem.Click
        Try
            Dim Frm As New FrmRecepcionDocumentosGUIAS
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub GuíasAutomáticasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíasAutomáticasToolStripMenuItem.Click
        Try
            Dim Frm As New FrmRegistro_auto_guias
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub GuiaTransportistaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuiaTransportistaToolStripMenuItem.Click
        Try
            Dim Frm As New FrmGuiasTranspor
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Guía Transportista"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub SimuladorGuíaTransportistaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimuladorGuíaTransportistaToolStripMenuItem.Click
        Try
            Dim Frm As New FrmSimuladorCarga
            Frm.StartPosition = FormStartPosition.Manual

            Frm.Width = 990 '1330
            Frm.Height = 610 '685
            Frm.ControlBox = True

            'Frm.MinimizeBox = True
            'Frm.MaximizeBox = True
            Frm.Text = "Simulador Guía Transportista"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RecepciónCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónCargaToolStripMenuItem.Click
        Try
            Dim Frm As New FrmRegCargoBultos
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Recepción Carga"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub EntregaCargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaCargoToolStripMenuItem.Click
        Try
            Dim Frm As New frmEntregaCarga
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Entrega Carga"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub IngresoDeBultoAAlmacenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeBultoAAlmacenToolStripMenuItem.Click
        Try
            Dim Frm As New FrmIngreAnaBulto
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Ingreso de Bulto a Almacén"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub BajarBultosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BajarBultosToolStripMenuItem.Click
        Try
            Dim Frm As New frm_recepcion_quitarbultos
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub DevoluciónDeCargosConfirmaciónDeEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub VentaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaCargaToolStripMenuItem.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim Frm As New FrmVentaContado
            Frm.StartPosition = FormStartPosition.Manual
            Frm.MaximizeBox = False
            Frm.ControlBox = True
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MessageBox.Show(EXC.ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        '    objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        '    objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        '    If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
        '        MsgBox("No tiene TURNO aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        Exit Sub
        '    End If
        '    objLIQUI_TURNOS = Nothing

        '    Dim Frm As New FrmCargaAsegurada
        '    Frm.ControlBox = True
        '    Frm.MinimizeBox = False
        '    Frm.MaximizeBox = False
        '    Frm.StartPosition = FormStartPosition.CenterScreen
        '    Acceso.Asignar(Frm)
        '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '        Frm.hnd = Hnd
        '        Frm.ShowDialog(Me)
        '    Else
        '        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch EXC As Exception
        '    MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        'End Try
    End Sub

    'Private Sub PostVentaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostVentaCargaToolStripMenuItem.Click
    '    Try
    '        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
    '        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
    '        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
    '            MsgBox("No tiene TURNO aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            Exit Sub
    '        End If
    '        objLIQUI_TURNOS = Nothing

    '        Dim a As New FrmVentaCargaContado
    '        a.txtCosto_Total.ReadOnly = False
    '        a.txtFecha.ReadOnly = False
    '        a.txtSERIE.Enabled = True
    '        a.txtNroDocFACBOL.Enabled = True

    '        a.txtFecha.BackColor = Color.Aqua
    '        a.txtCosto_Total.BackColor = Color.Aqua
    '        a.bControlFiscalizacion = True

    '        a.ControlBox = True
    '        a.MinimizeBox = False
    '        a.MaximizeBox = False
    '        a.StartPosition = FormStartPosition.CenterScreen
    '        Acceso.Asignar(a)
    '        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '            a.hnd = Hnd
    '            a.ShowDialog(Me)
    '        Else
    '            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '        a = Nothing
    '    Catch EXC As Exception
    '        MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
    '    End Try
    'End Sub


    Private Sub RegistroComprobanteVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroComprobanteVentaToolStripMenuItem.Click
        Try
            Dim Frm As New FrmRegistroGenerico
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub FacturaciónCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónCréditoToolStripMenuItem.Click
        Try
            Dim Frm As New FrmFacturas
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Facturación Crédito"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub IngresoDeCargosDeFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeCargosDeFacturasToolStripMenuItem.Click
        Try
            Dim Frm As New FrmIngresoCargoFacturacion
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Ingreso de Cargos de Facturas"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FacturaciónClienteTipoIIIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónClienteTipoIIIToolStripMenuItem.Click
        Try
            Dim Frm As New FrmFacturarPreFacturas
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Facturación Cliente Tipo III"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RefacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefacturaciónToolStripMenuItem.Click
        Try
            Dim Frm As New frmrefacturacion
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub FacturaciónEspecialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónEspecialToolStripMenuItem.Click
        Try
            Dim Frm As New frmfacturaotro
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.MaximizeBox = True
            Frm.MinimizeBox = True
            Frm.Text = "Facturación Especial"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ListaDeCobranzaPasajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListaDeCobranzaPasajesToolStripMenuItem.Click
        Try
            nFrmCreaRelaCobra = New FrmCreaRelaCobra
            nFrmCreaRelaCobra.ControlBox = True
            nFrmCreaRelaCobra.MinimizeBox = False
            nFrmCreaRelaCobra.MaximizeBox = False
            nFrmCreaRelaCobra.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(nFrmCreaRelaCobra)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                nFrmCreaRelaCobra.hnd = Hnd
                nFrmCreaRelaCobra.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub PagoDePasajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagoDePasajesToolStripMenuItem.Click
        Try
            Dim frm As New FrmPagoPasa
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Pago de Pasajes"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub VerificaciónDePCEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerificaciónDePCEToolStripMenuItem.Click
        Try
            Dim Frm As New FrmConsulFactuCheckPce
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Verificación de PCE"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub GeneraciónPrefacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónPrefacturaToolStripMenuItem.Click
        Try
            Dim frm As New FrmPrefacturacion
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Generación Prefactura"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub OficinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OficinaToolStripMenuItem.Click
        Try
            Dim objLIQUI_OFICINAS As New ClsLbTepsa.dtoLiqui_Oficinas

            Dim frm As New FrmAperLiquiOfi
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                objLIQUI_OFICINAS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
                objLIQUI_OFICINAS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                If objLIQUI_OFICINAS.SP_LISTAR_LIQUI_OFICINAS.Count <= 0 Then
                    frm.hnd = Hnd
                    frm.ShowDialog()
                Else
                    MsgBox("Ya existe OFICINA aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            objLIQUI_OFICINAS = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub TurnoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnoToolStripMenuItem.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS

            Dim frm As New FrmAperLiquiTurno
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
                objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                    frm.hnd = Hnd
                    frm.ShowDialog()
                Else
                    MsgBox("Ya existe TURNO aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            objLIQUI_TURNOS = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub TurnoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnoToolStripMenuItem1.Click
        Try
            Dim Frm As New FrmAperLiqui
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub LiquidacionTurnoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidacionTurnoToolStripMenuItem.Click
        Dim lm_iIdAgencia As Long
        Try
            lm_iIdAgencia = dtoUSUARIOS.m_iIdAgencia
            'Dim frm As New FrmCierre_LiquiTurno
            nFrmCierre_LiquiTurno = New FrmCierre_LiquiTurno
            nFrmCierre_LiquiTurno.ControlBox = True
            nFrmCierre_LiquiTurno.MinimizeBox = False
            nFrmCierre_LiquiTurno.MaximizeBox = False
            nFrmCierre_LiquiTurno.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(nFrmCierre_LiquiTurno)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                nFrmCierre_LiquiTurno.hnd = Hnd
                nFrmCierre_LiquiTurno.ShowDialog(Me)
                dtoUSUARIOS.m_iIdAgencia = lm_iIdAgencia
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub LiquidaciónOficinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lm_iIdAgencia As Long
        Try
            lm_iIdAgencia = dtoUSUARIOS.m_iIdAgencia

            Dim Frm As New FrmCierre_LiquiOfi
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog(Me)
                dtoUSUARIOS.m_iIdAgencia = lm_iIdAgencia
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub LiquidaciónTurnoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaciónTurnoToolStripMenuItem.Click
        Dim lm_iIdAgencia As Long
        Try
            lm_iIdAgencia = dtoUSUARIOS.m_iIdAgencia

            Dim frm As New FrmCierre_Liquidacion
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Text = "Liquidación Turno"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog(Me)
                dtoUSUARIOS.m_iIdAgencia = lm_iIdAgencia
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub GuíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíasToolStripMenuItem.Click
        Try
            Dim Frm As New FrmMigrarGuiasDbf
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Guías"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasToolStripMenuItem.Click
        Try
            Dim frm As New FrmMigrarFacturasDbf
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Facturas"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    'Private Sub ComisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComisiónToolStripMenuItem.Click
    '    Try
    '        Dim Frm As New FrmCalcComi
    '        frm.StartPosition = FormStartPosition.Manual
    '        frm.ControlBox = True
    '        frm.Text = "Comisión"
    '        Acceso.Asignar(frm)
    '        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '            Frm.MdiParent = Me
    '            Frm.hnd = Hnd
    '            Frm.Show()
    '        Else
    '            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch EXC As Exception
    '        MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
    '    End Try
    'End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        Try
            Dim Frm As New frm_configura_mensajeria
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Configuración"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub PúblicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PúblicaToolStripMenuItem.Click
        Try
            Dim frm As New FrmManteMensajeria
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Pública"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub PersonalizadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalizadaToolStripMenuItem.Click
        Try
            nFrmManteMensajeriaPersona = New FrmManteMensajeriaPesona
            nFrmManteMensajeriaPersona.StartPosition = FormStartPosition.Manual
            nFrmManteMensajeriaPersona.ControlBox = True
            nFrmManteMensajeriaPersona.Text = "Personalizada"
            Acceso.Asignar(nFrmManteMensajeriaPersona)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                nFrmManteMensajeriaPersona.MdiParent = Me
                nFrmManteMensajeriaPersona.hnd = Hnd
                nFrmManteMensajeriaPersona.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Acceso.Eliminar(nFrmManteMensajeriaPersona, G_Fila)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DatosClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosClientesToolStripMenuItem.Click
        Try
            Dim frm As New frmconsultadatosmensajeria
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Datos Clientes"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                'MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'G_Fila = Acceso.ObtieneFila(Me,me.hnd)
                Acceso.Eliminar(frm, G_Fila)
                '
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub SalidaMóvilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaMóvilToolStripMenuItem.Click
        Try
            Dim frm As New frmsalidamovil
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Salida Móvil"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub OperacionMóvilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperacionMóvilToolStripMenuItem.Click
        Try
            Dim ObjFrm As New FrmListaSolicitudesEntregas
            ObjFrm.StartPosition = FormStartPosition.Manual
            ObjFrm.ControlBox = True
            Acceso.Asignar(ObjFrm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                'nFrmManteMensajeriaPersona.MdiParent = Me
                'nFrmManteMensajeriaPersona.hnd = Hnd
                'nFrmManteMensajeriaPersona.Show()
                ObjFrm.MdiParent = Me
                ObjFrm.hnd = Hnd
                ObjFrm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjFrm = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        'Try
        '    Dim ObjFrm As New FrmListaSolicitudesEntregas
        '    'ObjFrm.ShowDialog()
        '    Acceso.Asignar(ObjFrm)
        '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '        ObjFrm.ShowDialog()
        '    Else
        '        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        '    ObjFrm = Nothing
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Try
        '    Dim frm As New FrmRecojoEntrega
        '    frm.ControlBox = True
        '    frm.MinimizeBox = False
        '    frm.MaximizeBox = False
        '    frm.Text = "Operación Móvil"
        '    frm.StartPosition = FormStartPosition.CenterScreen
        '    Acceso.Asignar(frm)
        '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '        frm.hnd = Hnd
        '        frm.ShowDialog()
        '    Else
        '        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub

    Private Sub ProgramaciónRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramaciónRecojoToolStripMenuItem.Click
        Try
            Dim Frm As New frmProgramaRecojo
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.Text = "Programación Recojo"
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub ControlDeOperacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeOperacionesToolStripMenuItem.Click
        Try
            Dim frm As New frmConfiguracionTerminal
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Text = "Control de Operaciones"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub ControlAccesoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New frmControlAccesos
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Control Acceso"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ControlUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlUsuarioToolStripMenuItem.Click
        Try
            Dim frm As New frmControlUsuarios
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Control Usuario"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ImpresoraTérmicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpresoraTérmicaToolStripMenuItem.Click
        Try
            Dim frm As New FrmControl_Impresoras
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Impresora Térmica"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ControlCargaAseguradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlCargaAseguradaToolStripMenuItem.Click
        Try
            Dim frm As New FrmOpciones
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Control Carga Asegurada"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub SistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SistemaToolStripMenuItem.Click
        Try
            Dim Frm As New frmConfiuracionSistemas
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.Text = "Sistema"
            Frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub VentaPasajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaPasajeToolStripMenuItem.Click
        Try
            Dim frm As New frmventapasaje
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Venta Pasaje"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ExcesoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcesoToolStripMenuItem.Click
        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
            MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        objLIQUI_TURNOS = Nothing

        Try
            Dim frm As New Frmexcesoequipaje
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Otros Ingresos"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub GirosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GirosToolStripMenuItem.Click
        Try
            Dim a As New FrmVentaGiros
            a.txtFecha.ReadOnly = False
            a.ControlBox = True
            a.MinimizeBox = False
            a.MaximizeBox = False
            a.Text = "Giros"
            a.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(a)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.hnd = Hnd
                a.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub VentaGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaGeneralToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulVentaPasaTotales
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Venta General"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub CompaginaciónReciboCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompaginaciónReciboCajaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulVentaPasaReciTotales
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Compaginación Recibo Caja"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ComprobantesGratuitosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprobantesGratuitosToolStripMenuItem.Click
        Dim flag As Boolean = False
        Try
            Dim frm As New frmcomprobantesgratuitos
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Comprobantes Gratuitos"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ClientePorFuncionarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientePorFuncionarioToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulClienFunci
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Cliente por Funcionario"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub TarifaPúblicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifaPúblicaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulTariCarga
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifa Pública"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub TarifaPreferencialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifaPreferencialToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulTariClien
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifa Preferencial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub EmitidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmitidasToolStripMenuItem.Click
        Try
            Dim Frm As New FrmConsulGuiasEmi
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Emitida"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ConCargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConCargoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiasCargo
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Con Cargo"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub PorOrígenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorOrígenToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiasEmiFisca
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Por Orígen"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub EstadoGuíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoGuíasToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulguiasPendfact
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Estado Guías"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub VentaCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaCréditoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFacturados
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Venta Crédito"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub EntregaDeCargosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaDeCargosToolStripMenuItem.Click
        Try

            Dim frm As New FrmConsulGuiasEmiEntreCarga
            '
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Entrega de Cargo"
            '
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                '
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub CargoDocumentarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoDocumentarioToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiasCargoDocu
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Cargo Documentario"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub RetornoDeGuíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetornoDeGuíasToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiasRetor
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Retorno de Guías"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub PrefacturaEmitidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrefacturaEmitidaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulPreFactuEmi
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Prefactura Emitida"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FacturaEmitidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaEmitidaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmi
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Factura Emitida"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub VentaPorMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaPorMesToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuCompartivo
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Venta por Mes"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ControlCorrelativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlCorrelativoToolStripMenuItem.Click
        Try
            Dim frm As New FrmControlCorrelativo
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Control Correlativo"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub VentasPorMesSinNotaCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasPorMesSinNotaCréditoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuCompartivo_sin_notacred
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            'frm.Text = "Ventas por Mes sin Nota Crédito"
            frm.Text = "Cuadro de Facturación Crédito y Cobranzas x G.E."
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub CuentaCorrienteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaCorrienteToolStripMenuItem1.Click
        Try
            Dim frm As New FrmConsulFactuEmiPago
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Cuenta Corriente"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub LíneaCréditoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LíneaCréditoToolStripMenuItem1.Click
        Try
            Dim frm As New FrmConsulCtaCte
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Línea Crédito"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub VentaClienteCorporativoNoCorporativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaClienteCorporativoNoCorporativoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiConta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Venta Cliente Corporativo/No Corporativo"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub VentaPorFuncionarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaPorFuncionarioToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiContaFunci
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Venta por Funcionario"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub MovimientoMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientoMensualToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuGe
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Movimiento Mensual"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub PagoContraEntregaFiscalizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagoContraEntregaFiscalizaciónToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiContaPCE
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Pago Contra Entrega (Fiscalización)"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BoletasYFacturasPCECobranzaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoletasYFacturasPCECobranzaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiContaGerencia
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Boletas y Facturas P.C.E (Cobranza)"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub VentasConDescuentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasConDescuentoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiDescu
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Ventas con Descuento"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub GuíaTransportistaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíaTransportistaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiaTranspor
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Guía Transportista"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub BusIdaRetornoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusIdaRetornoToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulGuiaIdaRetorno
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Bus Ida-Retorno"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub BultosIngresadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BultosIngresadosToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulDespa
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Bultos Ingresados"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub BultosLeídosXPdtContraFormaManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BultosLeídosXPdtContraFormaManualToolStripMenuItem.Click
        Try
            Dim frm As New frm_pdt_vs_manual
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Text = "Bultos leídos x Pdt contra forma manual"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub EntregaBultoEnRecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaBultoEnRecepciónToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiEntreManu
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Entrega Bulto en Recepción"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub RecepciónDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónDocumentosToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulEntregaDocu
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Recepción Documentos"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DocumentosRecepcionadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosRecepcionadoToolStripMenuItem.Click
        Try
            Dim frm As New frmconsulta_dctos_despachados
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Documentos Recepcionados"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DocumentosEntregadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosEntregadosToolStripMenuItem.Click
        Try
            Dim frm As New frmconsulta_dctos_entregados
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Documentos Entregados"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BultosLeídosPorPdtRecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BultosLeídosPorPdtRecepciónToolStripMenuItem.Click
        Try
            Dim frm As New frm_pdt_recepcion_vs_manual
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Text = "Bultos leídos por Pdt Recepción"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub BultosLeídosPorPdtRepartoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BultosLeídosPorPdtRepartoToolStripMenuItem.Click
        Try
            Dim frm As New frm_pdt_reparto_vs_manual
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Bultos leídos por Pdt Reparto"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub BultosLeídosPorPdtAlmacenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BultosLeídosPorPdtAlmacenToolStripMenuItem.Click
        Try
            Dim frm As New frm_pdt_almacen_vs_manual
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Bultos leídos por Pdt Almacen"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub SeguimientoDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoDocumentoToolStripMenuItem.Click
        Try
            Dim frm As New frmconsultaguiatransportista_xdcto
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Seguimiento Documento"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub DespachoConRecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespachoConRecepciónToolStripMenuItem.Click
        Try
            Dim frm As New frmdespacho_vs_recepcion
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Despacho con Recepción"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub DestinosDiferentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinosDiferentesToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuDife
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Destinos Diferentes"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DespachoXDíaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespachoXDíaToolStripMenuItem.Click
        Try
            Dim frm As New frmseguimiento_despacho_x_dia
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Despacho por Día"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub EstadosDeEnvioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadosDeEnvioToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulFactuEmiContaEsta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Estados de Envio"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub LiquidacionesPorAgenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidacionesPorAgenciaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsultaliquidaciones
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Liquidaciones por Agencia"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub SssToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SssToolStripMenuItem.Click
        Try
            '
            Dim frm As New frm_consultagral
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Consulta General"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
        '
    End Sub

    Private Sub IngresosVsSalidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosVsSalidasToolStripMenuItem.Click
        Try
            Dim frm As New frm_consulta_ingreso_vs_salida
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Ingresos vs Salidas"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub ConsultaXDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaXDocumentosToolStripMenuItem.Click
        Try
            Dim frm As New frmConsultaDocumento
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1043 '990 '1330
            frm.Height = 635 '620 '685
            frm.ControlBox = True
            frm.Text = "Consulta de Documento"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
        'Try
        '    Dim frm As New FrmConsultaGeneral2
        '    frm.StartPosition = FormStartPosition.Manual
        '    frm.ControlBox = True
        '    frm.Text = "Consulta x Documento(s)"
        '    Acceso.Asignar(frm)
        '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '        frm.MdiParent = Me
        '        frm.hnd = Hnd
        '        frm.Show()
        '    Else
        '        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        'End Try
    End Sub

    Private Sub PorFuncionarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorFuncionarioToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulComiFunci
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Por Funcionario"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub PorAgenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorAgenciaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulComiConce
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Por Agencia"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub MensajeriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MensajeriaToolStripMenuItem.Click
        Try
            Dim frm As New FrmConsulSolicitudMensajeria
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Mensajeria"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Acceso.Eliminar(frm, G_Fila)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RepartoPorResponsableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepartoPorResponsableToolStripMenuItem.Click
        Try
            Dim frm As New frm_consulta_reparto_recojo
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.Text = "Reparto por Responsable"
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub SolicitudDeRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeRecojoToolStripMenuItem.Click
        Try
            Dim frm As New FrmSolicitudRecojo
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub AdministraciónDeRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministraciónDeRecojoToolStripMenuItem.Click
        Try
            Dim frm As New FrmAsignacionRecojo
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ProgramaciónDeRutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramaciónDeRutaToolStripMenuItem.Click
        Try
            Dim frm As New FrmProgramacionRuta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    'Private Sub GuíaDeEnvíoPCEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíaDeEnvíoPCEToolStripMenuItem.Click
    '    Try
    '        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
    '        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
    '        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
    '            MsgBox("No tiene TURNO aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            Exit Sub
    '        End If
    '        objLIQUI_TURNOS = Nothing

    '        Dim Frm As New FrmCargaAsegurada
    '        Frm.StartPosition = FormStartPosition.Manual
    '        Frm.MaximizeBox = False
    '        Frm.ControlBox = True
    '        Acceso.Asignar(Frm)
    '        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '            Frm.MdiParent = Me
    '            Frm.hnd = Hnd
    '            Frm.Show()
    '        Else
    '            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch EXC As Exception
    '        MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
    '    End Try    
    'End Sub

    Private Sub MantenimientoGEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoGEToolStripMenuItem.Click
        Dim frm As New FrmMantenimientoGuia
        frm.StartPosition = FormStartPosition.Manual
        frm.ControlBox = True
        Acceso.Asignar(frm)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.MdiParent = Me
            frm.hnd = Hnd
            frm.Show()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MantenimientoVentaContadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoVentaContadoToolStripMenuItem.Click

        Dim frm As New FrmMantenimientoContado
        frm.StartPosition = FormStartPosition.Manual
        frm.ControlBox = True
        Acceso.Asignar(frm)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.MdiParent = Me
            frm.hnd = Hnd
            frm.Show()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
            MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        objLIQUI_TURNOS = Nothing

        Dim frm As New frmCancelarPCE
        frm.StartPosition = FormStartPosition.Manual
        frm.MaximizeBox = False
        frm.ControlBox = True
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub GuíaDeEnvíoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuíaDeEnvíoToolStripMenuItem.Click
        Dim frm As New FrmGuia
        frm.StartPosition = FormStartPosition.Manual
        frm.MaximizeBox = False
        frm.ControlBox = True
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PostVentaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostVentaCargaToolStripMenuItem.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MsgBox("No tiene TURNO aperturada", MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim a As New FrmVentaCargaContado
            a.txtCosto_Total.ReadOnly = False
            a.txtFecha.ReadOnly = False
            a.txtSERIE.Enabled = True
            a.txtNroDocFACBOL.Enabled = True

            a.txtFecha.BackColor = Color.Aqua
            a.txtCosto_Total.BackColor = Color.Aqua
            a.bControlFiscalizacion = True

            a.ControlBox = True
            a.MinimizeBox = False
            a.MaximizeBox = False
            a.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(a)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.hnd = Hnd
                a.ShowDialog(Me)
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            a = Nothing
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub AperturaOficinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaOficinaToolStripMenuItem.Click
        Try
            Dim objOficina As New dtoCierreOficina

            Dim frm As New FrmAperturaLiquidacion
            frm.ControlBox = True
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)

            frm.hnd = Hnd
            frm.ShowDialog()
            objOficina = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub LiquidacionDiariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidacionDiariaToolStripMenuItem.Click
        Dim objOficina As New dtoCierreOficina
        Dim frm As New FrmLiquidacionDiaria
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ControlBox = True
        Acceso.Asignar(frm)
        frm.MdiParent = Me
        frm.hnd = Hnd
        frm.Show()
    End Sub

    Private Sub ConsultaToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem3.Click
        Dim frm As New FrmMonitoreos
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.MaximizeBox = False
        frm.ControlBox = True
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim f As frmAcercaDe = Nothing
        Try
            f = New frmAcercaDe
            f.StartPosition = FormStartPosition.CenterScreen
            f.MdiParent = Me
            f.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub FacturaciónEspecialToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónEspecialToolStripMenuItem1.Click
        Dim f As FrmFacturacionEspecial = Nothing
        Try
            f = New FrmFacturacionEspecial
            f.StartPosition = FormStartPosition.CenterScreen
            f.Text = "Facturación Especial Crédito"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComisiónConcesionarioFuncionarioCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComisiónConcesionarioFuncionarioCargaToolStripMenuItem.Click
        Try
            Dim Frm As New FrmCalcComi
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Comisión"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ComisionFuncionarioPasajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComisionFuncionarioPasajeToolStripMenuItem.Click
        Dim f As frmComisionPasajes = Nothing
        Try
            f = New frmComisionPasajes
            f.Text = "COMISION DE PASAJES"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    '----------------------------------------------------------------------------------------------------------------
    '--------------------------------- Formularios Desarrollados por Aldo Chavarria ---------------------------------
    '----------------------------------------------------------------------------------------------------------------

    '------------------------------------ Formulario Mantenimiento de Checkpoint ------------------------------------
    Private Sub TSMICheckpoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMICheckpoint.Click
        Dim f As frmMantenimientoCheckpoint = Nothing
        Try
            f = New frmMantenimientoCheckpoint
            f.Text = "MANTENIMIENTO DE CHECKPOINT"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '--------------------------------- Formulario Mantenimiento de Salida de Buses ----------------------------------
    Private Sub TSMISalidaBus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As frmProgramacionVehiculo = Nothing
        Try
            f = New frmProgramacionVehiculo
            f.Text = "LISTA DE BUSES PARA DEPACHO DE CARGA"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '--------------------------------- Formulario de Generación de Guía de Remisión ----------------------------------
    Private Sub TSMIGuiaRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMIGuiaRemision.Click
        Dim f As frmGuiaRemisionTransportista = Nothing
        Try
            f = New frmGuiaRemisionTransportista
            f.Text = "GENERACION DE GUIA DE REMISION"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DevoluciònPorLimiteDeTiempoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevoluciònPorLimiteDeTiempoToolStripMenuItem.Click
        Dim f As Frm_DevolucionLimiteTiempo = Nothing
        Try
            f = New Frm_DevolucionLimiteTiempo
            'f.Text = "REPORTE DEVOLUCION LIMITE DE TIEMPO"
            Acceso.Asignar(f)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                f.MdiParent = Me
                'Frm.hnd = Hnd
                f.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '--------- Obtener Usuario de Red ------------- 21-05-2013
    'Private Sub S_InicializaDatosUsuario()
    '    'Inicializamos datos del usuario

    '    Dim lcls_Utilitarios As New Cls_Utilitarios
    '    With lcls_Utilitarios
    '        gStr_CodUsuario = .F_ObtenerDatosUsuarioRed(1)
    '    End With
    'End Sub
    Private Sub TarifarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifarioToolStripMenuItem.Click
        Try
            Dim frm As FrmTarifarioCliente = New FrmTarifarioCliente
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifario Cliente"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Private Sub Carga2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Carga2ToolStripMenuItem.Click
        Try
            Dim frm As FrmTarifarioPublico = New FrmTarifarioPublico
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Tarifario Publico"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Private Sub Tarifario2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tarifario2ToolStripMenuItem.Click
        Try
            Dim frm As FrmTarifarioPerso = New FrmTarifarioPerso
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Private Sub SubCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubCuentaToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor

            Dim frm As FrmClienteSubcuenta = New FrmClienteSubcuenta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor = Cursors.Default
        Catch EXC As Exception
            Cursor = Cursors.Default
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub ChoferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChoferToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmChofer = New FrmChofer
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor = Cursors.Default
        Catch EXC As Exception
            Cursor = Cursors.Default
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub ServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServicioToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmTarifaServicio = New FrmTarifaServicio
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor = Cursors.Default
        Catch EXC As Exception
            Cursor = Cursors.Default
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub ClienteACarteraDeFuncionarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteACarteraDeFuncionarioToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmAprobacionClienteCartera = New FrmAprobacionClienteCartera
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ClienteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteToolStripMenuItem2.Click

    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
    End Sub

    Private Sub SalidaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaCargaToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmSalidaCarga = New FrmSalidaCarga
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1350
            frm.Height = 685
            'frm.WindowState = FormWindowState.Normal
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NivelDeServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NivelDeServicioToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmNivelServicio = New FrmNivelServicio
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1350
            'frm.Height = 685
            'frm.WindowState = FormWindowState.Normal
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmEnvioCarga = New frmEnvioCarga
            frm.StartPosition = FormStartPosition.Manual
            Dim intResolucionPantalla As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            If intResolucionPantalla.Width < 1280 Then
                frm.Width = 1000  '1275
                frm.Height = 640 '640
            Else
                frm.Width = 1275  '1275
                frm.Height = 640 '640
            End If
            'frm.WindowState = FormWindowState.Normal
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub LineaDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineaDeCréditoToolStripMenuItem.Click
        Try
            Dim frm As New frmLineaCredito2
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1275 '1330
            frm.Height = 640 '685
            frm.ControlBox = True
            frm.Text = "Línea de Crédito"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub VentasPorMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasPorMesToolStripMenuItem.Click
        Try
            Dim frm As New frmVentasGEFactura
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1275 '1330
            frm.Height = 640 '685
            frm.ControlBox = True
            frm.Text = "Guías de Envío Facturadas"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub PruebaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebaToolStripMenuItem2.Click
        Try
            Dim frm As New frmClienteCuentaCorriente
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1275 '1330
            frm.Height = 640 '685
            frm.ControlBox = True
            frm.Text = "Saldo Pendiente por Cobrar"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub ActualizarPagosDeClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarPagosDeClienteToolStripMenuItem.Click
        Try
            Dim frm As New frmActualizarPagosCliente
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                'frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub FueraDeZonaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FueraDeZonaToolStripMenuItem.Click
        'Try
        '    Dim frm As New frmFueraZona
        '    frm.StartPosition = FormStartPosition.Manual
        '    frm.Width = 990 '1330
        '    frm.Height = 610 '685
        '    frm.ControlBox = True
        '    frm.Text = "Fuera de Zona"
        '    Acceso.Asignar(frm)
        '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '        frm.MdiParent = Me
        '        'frm.hnd = Hnd
        '        frm.Show()
        '    Else
        '        MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        'End Try
    End Sub

    Private Sub EntregaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaCargaToolStripMenuItem.Click
    End Sub

    Private Sub EntregarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregarToolStripMenuItem.Click
        Try
            Dim frm As New frmEntrega
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1058 '1095 '1180 '990 '1330
            frm.Height = 620 '620 '685
            frm.ControlBox = True
            frm.Text = "Entrega de Carga"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub SalidaDeBultosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaDeBultosToolStripMenuItem.Click
        Try
            Dim frmUsuarioConfirmar As New frmUsuarioConfirmar

            frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
            frmUsuarioConfirmar.txtUsuario.Text = dtoUSUARIOS.iLOGIN
            frmUsuarioConfirmar.txtContraseña.Focus()

            frmUsuarioConfirmar.ShowDialog()
            If frmUsuarioConfirmar.Resultado = 0 Then
                Return
            End If
            dtoUSUARIOS.IdLogin = frmUsuarioConfirmar.IDUsuario

            Dim frm As New frmEntregaSalidaBulto
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 791 '990 '1330
            frm.Height = 582 '620 '685
            frm.ControlBox = True
            frm.Text = "Salida Bulto de Almacén"
            frm.Usuario = frmUsuarioConfirmar.Usuario
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub ResultadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultadoToolStripMenuItem.Click
        Try
            Dim frm As New frmEntregaResultado
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 913 '990 '1330
            'frm.Height = 494 '620 '685
            frm.ControlBox = True
            frm.Text = "Informe de Resultado"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub


    Private Sub PanelControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelControlToolStripMenuItem.Click
        Try
            Dim frm As New frmEntregaPanelControl
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 947 '990 '1330
            'frm.Height = 523 '620 '685
            frm.ControlBox = True
            frm.Text = "Panel de Control"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub EntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaToolStripMenuItem.Click
        Try
            Dim frm As New frmBonoEntrega
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 947 '990 '1330
            'frm.Height = 523 '620 '685
            frm.ControlBox = True
            frm.Text = "Bonos : Entrega"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub ObjetivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjetivoToolStripMenuItem.Click
        Try
            Dim frm As New frmEntregaObjetivo
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 947 '990 '1330
            'frm.Height = 523 '620 '685
            frm.ControlBox = True
            frm.Text = "Objetivo : Entrega"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem.Click
    End Sub

    Private Sub AsociarTipoGastoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmCiudadTipoGasto = New frmCiudadTipoGasto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GestiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestiónToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmGasto = New frmGasto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360 
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TarifaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifaToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmTarifaGasto = New frmTarifaGasto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AsociarTipoPagoACiudadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsociarTipoPagoACiudadToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmCiudadTipoGasto = New frmCiudadTipoGasto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AsignarCargaARepartoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarCargaARepartoToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmReparto = New frmReparto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub MóvilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MóvilToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmMovil = New frmMovil
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub BonosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BonosToolStripMenuItem2.Click
    End Sub

    Private Sub AsociarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsociarProveedorToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmProveedorOperacion = New frmProveedorOperacion
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1300
            'frm.Height = 650
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub EntregaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaToolStripMenuItem1.Click
        Try
            Dim frm As New frmEntregaBonos
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 791 '990 '1330
            'frm.Height = 582 '620 '685
            frm.ControlBox = True
            frm.Text = "Bonos"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try

    End Sub

    Private Sub OperaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperaciónToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmBonoOperacion = New frmBonoOperacion
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            frm.Width = 1300
            frm.Height = 650
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub CorporativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorporativoToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As FrmGestionCliente = New FrmGestionCliente
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.Width = 1300
            frm.Height = 650
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub NoCorporativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoCorporativoToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmGestionClienteNoCorporativo = New frmGestionClienteNoCorporativo
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.Width = 1300
            frm.Height = 650
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub EntregaEspecialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaEspecialToolStripMenuItem.Click
        Try
            Dim frm As New frmEntregaEspecial
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1058 '1095 '1180 '990 '1330
            'frm.Height = 620 '620 '685
            frm.ControlBox = True
            frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try

    End Sub

    Private Sub MantenimientoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem1.Click
        Try
            Dim frm As New frmDevolucionCargo
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1058 '1095 '1180 '990 '1330
            'frm.Height = 620 '620 '685
            frm.ControlBox = True
            'frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub OperaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperaciónToolStripMenuItem1.Click
        Try
            Dim Frm As New FrmConsulDevoCargos
            Frm.ControlBox = True
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.StartPosition = FormStartPosition.CenterScreen
            Frm.Text = "Devolución de Cargos Confirmación de Entrega"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.hnd = Hnd
                Frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub CierreProvisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreProvisiónToolStripMenuItem.Click
        Try
            Dim frm As New frmCierreProvision
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1058 '1095 '1180 '990 '1330
            frm.Height = 620 '620 '685
            frm.ControlBox = True
            'frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub TeleventaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeleventaToolStripMenuItem.Click
        Try
            Dim frm As New frmTeleventa
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1058 '1095 '1180 '990 '1330
            frm.Height = 620 '620 '685
            frm.ControlBox = True
            'frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub EquipajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipajesToolStripMenuItem.Click
        Try
            'If dtoUSUARIOS.agencia <> 51 And dtoUSUARIOS.agencia <> 3932 Then
            'MessageBox.Show("No tiene acceso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Exit Sub
            'End If

            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim Frm As New frmEquipajes
            Frm.StartPosition = FormStartPosition.Manual
            Frm.MaximizeBox = False
            Frm.ControlBox = True
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MessageBox.Show(EXC.ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaveToolStripMenuItem.Click
        Try
            Dim frm As frmUsuarioClave = New frmUsuarioClave
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.hnd = Hnd
                frm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim lista As ArrayList = huella.ObtenerDispositivo()
    '        For i As Integer = 0 To lista.Count - 1
    '            Me.ComboBox1.Items.Add(lista(i))
    '        Next
    '        If Me.ComboBox1.Items.Count > 0 Then
    '            Me.ComboBox1.SelectedIndex = 0
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        huella.AbrirDispositivo(Me.ComboBox1.SelectedIndex)
    '        huella.LectorAutomatico(True, Me.Handle.ToInt32)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim intAncho As Integer, intAlto As Integer

    '        huella.ObtenerInfoDispositivo()
    '        intAncho = huella.Ancho
    '        intAlto = huella.Alto

    '        Dim iError As Int32

    '        ReDim imagen1(intAncho * intAlto)

    '        huella.CapturarHuella(imagen1)
    '        'huella.MostrarHuella(imagen1, pictureBox1)
    '        huella.CrearPlantilla(imagen1, plantilla1)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
    '    huella.CerrarDispositivo()
    'End Sub

    'Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        'huella.GrabarHuella(imagen1)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button6_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim ahuella() As Byte
    '        'huella.CargarHuella(1, ahuella)
    '        huella.ObtenerInfoDispositivo()
    '        '
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim intAncho As Integer, intAlto As Integer
    '        huella.ObtenerInfoDispositivo()
    '        intAncho = huella.Ancho
    '        intAlto = huella.Alto

    '        Dim iError As Int32

    '        ReDim imagen2(intAncho * intAlto)

    '        huella.CapturarHuella(imagen2, 10000, PictureBox3.Handle.ToInt32, 50)
    '        'huella.CapturarHuella(imagen2)
    '        'huella.MostrarHuella(imagen2, PictureBox3)
    '        huella.CrearPlantilla(imagen2, plantilla2)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button8_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim intError As Integer
    '        Dim intNivelSeguridad As Integer = 4 'normal
    '        Dim blnCoinciden As Boolean

    '        huella.VerificarPlantilla(plantilla1, plantilla2, intNivelSeguridad, blnCoinciden)
    '        If blnCoinciden Then
    '            MessageBox.Show("Coinciden")
    '        Else
    '            MessageBox.Show("No Coinciden")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Button9_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim intError As Integer
    '        Dim intNivelSeguridad As Integer = 4 'normal
    '        Dim blnCoinciden As Boolean

    '        'huella.CargarHuella(1, plantilla2)

    '        huella.VerificarPlantilla(plantilla1, plantilla2, intNivelSeguridad, blnCoinciden)
    '        If blnCoinciden Then
    '            MessageBox.Show("Coinciden")
    '        Else
    '            MessageBox.Show("No Coinciden")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Protected Overrides Sub WndProc(ByRef msg As Message)
    '    Dim blnActivo As Boolean
    '    huella.HuellaCapturada(msg, blnActivo)
    '    If blnActivo Then
    '        Button7_Click(Nothing, Nothing)
    '    End If
    '    MyBase.WndProc(msg)
    'End Sub

    'Public Sub CreateBitmapAtRuntime()
    '    pictureBox1.Size = New Size(210, 110)
    '    Me.Controls.Add(pictureBox1)


    '    Dim flag As New Bitmap(200, 100)
    '    Dim flagGraphics As Graphics = Graphics.FromImage(flag)
    '    Dim red As Integer = 0
    '    Dim white As Integer = 11
    '    While white <= 100
    '        flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10)
    '        flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10)
    '        red += 20
    '        white += 20
    '    End While
    '    pictureBox1.Image = flag

    'End Sub

    'Private Sub Button10_Click(sender As System.Object, e As System.EventArgs)
    '    'CreateBitmapAtRuntime()

    '    Dim log As New LogSistemaTitan_prueba
    '    Dim img As Image = Me.pictureBox1.Image

    '    log.CrearFolderLog("c:\", "hlamas", "prueba")


    '    Dim ruta As String = "c:\log_titan\prueba\a.png" 'Path.PathSys
    '    Dim fs As New FileStream(ruta, FileMode.Append, FileAccess.Write)
    '    img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
    '    fs.Position = 0
    '    Dim longitud As Integer = Convert.ToInt32(fs.Length)
    '    Dim a() As Byte
    '    ReDim a(longitud)
    '    fs.Read(a, 0, longitud)
    '    fs.Close()
    'End Sub

    'Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
    '    Dim myGraphics As Graphics = PictureBox3.CreateGraphics()
    '    Dim s As Size = PictureBox3.Size
    '    Dim memoryImage As Bitmap = New Bitmap(s.Width, s.Height, myGraphics)
    '    Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
    '    memoryGraphics.CopyFromScreen(PictureBox3.Location.X, PictureBox3.Location.Y + 22, 0, 0, s)
    '    PictureBox2.Image = memoryImage

    '    Return
    '    Dim img As Image = PictureBox2.Image
    '    Dim ms As New MemoryStream
    '    Dim img2 As Image = img.Clone
    '    img2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    img2.Dispose()
    '    Dim m() As Byte
    '    m = ms.ToArray
    '    ms.Close()
    '    ms.Dispose()

    '    SaveJPGWithCompressionSetting(img, "c:\fingerprint.jpg", 10)

    '    Dim size As Long
    '    size = New FileInfo("c:\fingerprint.jpg").Length
    '    Dim fs As FileStream
    '    fs = New FileStream("c:\fingerprint.jpg", FileMode.Open)
    '    Dim b() As Byte
    '    ReDim b(size)
    '    fs.Read(b, 0, size)
    '    fs.Close()
    '    fs.Dispose()

    '    'huella.GrabarHuella(b)


    'End Sub

    'Public Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
    '    Dim j As Integer
    '    Dim encoders As ImageCodecInfo()

    '    encoders = ImageCodecInfo.GetImageEncoders()
    '    For j = 0 To encoders.Length
    '        If encoders(j).MimeType = mimeType Then
    '            Return encoders(j)
    '        End If
    '    Next j
    '    Return Nothing
    'End Function

    'Public Shared Sub SaveJPGWithCompressionSetting(ByVal image As Image, ByVal szFileName As String, ByVal lCompression As Long)
    '    Dim eps As EncoderParameters = New EncoderParameters(1)

    '    eps.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, lCompression)

    '    Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
    '    Try
    '        image.Save(szFileName, ici, eps)
    '    Catch exc As Exception
    '        MessageBox.Show(exc, " Atención !", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub AgenciaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgenciaToolStripMenuItem1.Click
        Try
            Dim frm As New frmConsultaEntrega
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1058 '1095 '1180 '990 '1330
            'frm.Height = 620 '620 '685
            frm.ControlBox = True
            'frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub DomicilioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DomicilioToolStripMenuItem.Click
        Try
            Dim frm As New frmConsultaEntregaDomicilio
            frm.StartPosition = FormStartPosition.Manual
            'frm.Width = 1058 '1095 '1180 '990 '1330
            'frm.Height = 620 '620 '685
            frm.ControlBox = True
            'frm.Text = "Entrega Especial"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub


    Private Sub PruebasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebasToolStripMenuItem.Click
        Form2.Show()
    End Sub


    Private Sub NumeradorDeComprobantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeradorDeComprobantesToolStripMenuItem.Click
        Try
            Dim frm As New frmConfiguracionComprobante
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            frm.Text = "Numerador de Comprobantes"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub AgenciaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgenciaToolStripMenuItem2.Click
        Try
            Dim Frm As New FrmAgencias
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Agencia"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub CpuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CpuToolStripMenuItem1.Click
        Try
            Dim Frm As New FrmCPU
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Cpu"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub CiudadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CiudadToolStripMenuItem1.Click
        Try
            Dim Frm As New FrmCiudades()
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Ciudad"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub PaísToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaísToolStripMenuItem1.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "1", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Try
            Dim Frm As New FrmDosCampos(Parametros)
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "País"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub DepartamentoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentoToolStripMenuItem1.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "2", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Try
            Dim Frm As New FrmDosCampos(Parametros)
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Departamento"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub ProvinciaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvinciaToolStripMenuItem1.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Try
            Dim Frm As New FrmDosCampos(Parametros)
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Provincia"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub DistritoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistritoToolStripMenuItem1.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DSITRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "4", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Try
            Dim Frm As New FrmDosCampos(Parametros)
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Distrito"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub FacturaAdicionalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AutorizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub EmisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub AutorizaciónToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutorizaciónToolStripMenuItem2.Click
        Try
            Dim Frm As New frmAutorizacion
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Autorización"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub FacturaciónAdicionalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NotaDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FacturaciónAdicionalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónAdicionalToolStripMenuItem1.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim Frm As New frmEmisionFacturaAdicional
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Emisión Factura Adicional"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub NotaDeCréditoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotaDeCréditoToolStripMenuItem1.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim Frm As New frmNotaCredito
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Emisión Nota de Crédito"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try

    End Sub

    Private Sub PruebaToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CanjeNotaCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanjeNotaCréditoToolStripMenuItem.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim Frm As New frmNotaCreditoCanje
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Canje Nota de Crédito / Anulación"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub DevoluciónDeCargosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevoluciónDeCargosToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strFechaComprobante As String = "30/09/2016"
        Dim strFechaServidor As String = "01/10/2016" 'FechaServidor(1)
        Dim dias As Long = DateDiff(DateInterval.Day, CType(strFechaComprobante, Date), CType(strFechaServidor, Date))
        If dias >= 1 Then
            If DatePart(DateInterval.Month, CDate(strFechaComprobante)) <> DatePart(DateInterval.Month, CDate(strFechaServidor)) Then

            End If
        End If
        MsgBox(dias)
    End Sub

    Private Sub AutorizaciónToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutorizaciónToolStripMenuItem.Click
        Try
            Dim Frm As New frmTarifarioAutorizacion
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Autorización de Tarifas"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub NotaDeDébitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotaDeDébitoToolStripMenuItem.Click
        Try
            Dim Frm As New frmNotaDebito
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Nota de Débito"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub TipoCambioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoCambioToolStripMenuItem.Click
        Try
            Dim Frm As New frmTipoCambio
            Frm.StartPosition = FormStartPosition.Manual
            Frm.ControlBox = True
            Frm.Text = "Tipo de Cambio"
            Acceso.Asignar(Frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Frm.MdiParent = Me
                'Frm.hnd = Hnd
                Frm.Show()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub

    Private Sub IngresarBolsaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarBolsaToolStripMenuItem.Click
        Try
            If dtoUSUARIOS.Portavalor = 2 Then
                MessageBox.Show("No tiene acceso", "Ingreso Bolsa al Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If dtoUSUARIOS.Cofre = 0 Then
                MessageBox.Show("No tiene acceso", "Ingreso Bolsa al Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim frm As frmBolsa = New frmBolsa
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "Ingreso Bolsa al Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub PortavalorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PortavalorToolStripMenuItem.Click
        Try
            Dim frm As frmPortavalor = New frmPortavalor
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub OperaciónToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperaciónToolStripMenuItem2.Click
        Try
            Dim frm As frmLiquidacionValores = New frmLiquidacionValores
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    'Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp.ValueChanged
    '    Dim obj As New dtoCierreOficina
    '    Dim dt As DataTable = obj.ListarUsuarioLiquidacion(Me.dtp.Value.ToShortDateString)
    '    With Me.dgv
    '        .DataSource = dt
    '    End With
    'End Sub

    Private Sub HorasExtrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorasExtrasToolStripMenuItem.Click
        Try
            Dim frm As frmHoraExtra = New frmHoraExtra
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try

    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    'Dim dblmonto As Double = FrmLiquidacionDiaria.MontoEfectivo(txt.Text.Trim, Me.cbo.SelectedValue, dtp.Value.ToShortDateString)
    '    'Me.Text = FormatNumber(dblmonto, 2)
    '    Cursor = Cursors.AppStarting
    '    Dim id As Integer, dblMonto As Double, intAgencia As Integer, intUsuario As Integer, strFecha As String
    '    Dim obj2 As New dtoCierreOficina
    '    With Me.dgv
    '        Dim dblTotal As Double = 0
    '        For Each row As DataGridViewRow In .Rows
    '            id = row.Cells("id").Value
    '            intAgencia = row.Cells("agencia").Value
    '            intUsuario = row.Cells("usuario").Value
    '            strFecha = Me.dtp.Value.ToShortDateString
    '            If intAgencia > 0 Then
    '                If intAgencia = 51 Then 'Or intAgencia = 3932 Then
    '                    dblMonto = FrmLiquidacionDiaria.MontoEfectivo(id, intAgencia, dtp.Value.ToShortDateString, intUsuario)
    '                    dblTotal += dblMonto
    '                    obj2.GrabarOficinaValor(strFecha, intAgencia, intUsuario, dblMonto, id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    '                ElseIf intAgencia = 2641 Then
    '                    dblMonto = FrmLiquidacionDiaria.MontoEfectivo(id, intAgencia, dtp.Value.ToShortDateString)
    '                    obj2.GrabarOficinaValor(strFecha, intAgencia, intUsuario, dblMonto, id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    '                End If

    '            End If
    '        Next
    '    End With
    '    Cursor = Cursors.Default
    'End Sub

    Private Function String2Bitmap(ByVal cad As String) As Bitmap
        Dim a As String = vbNull
        Dim ib As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(cad) 'Convert.FromBase64String(cad)
        a = System.Convert.ToBase64String(ib)
        Dim bytes() As Byte = Convert.FromBase64String(a)

        Dim bm As Bitmap = Nothing
        Dim ms As New MemoryStream(bytes)

        'Using ms As MemoryStream = New MemoryStream(bytes, 0, bytes.Length)
        'MS.Write(bytes, 0, bytes.Length)
        ''bm = Bitmap.FromStream(ms, True)
        'Dim img As Image = Image.FromStream(MS)

        'End Using
        'Return bm
    End Function
    
    Private Sub RutaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As frmRuta = New frmRuta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub ProveedorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub ProgramaciónDeRecojoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramaciónDeRecojoToolStripMenuItem.Click
        Try
            Dim frm As frmRecojoAcordado = New frmRecojoAcordado
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub VentaContadoEspecialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaContadoEspecialToolStripMenuItem.Click
        Try
            Dim frm As frmVentaContadoEspecial = New frmVentaContadoEspecial
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ruta As String, ruta2 As String, archivo As String
        archivo = "1.jpg"
        Dim rutaDestino As String = "\\192.168.200.80/recojo/2019/" & archivo
        Dim rutaOrigen As String = "\\192.168.200.80/tmp/" & archivo

        My.Computer.Network.UploadFile(rutaOrigen, rutaDestino, "administrador", "303tslPoseidon")
    End Sub

    Private Sub RutaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaToolStripMenuItem2.Click
        Try
            Dim frm As frmRuta = New frmRuta
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try

    End Sub

    Private Sub MantenimientoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem2.Click
        Try
            Dim frm As frmProveedor = New frmProveedor
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try

    End Sub

    Private Sub ConsultaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem2.Click
        Try
            Dim frm As frmConsultaRecojo = New frmConsultaRecojo
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub ResumenDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenDeVentasToolStripMenuItem.Click
        Try
            Dim frm As frmResumenVentas = New frmResumenVentas
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub TransferenciaAContabilidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaAContabilidadToolStripMenuItem.Click
        Try
            Dim frm As frmTransferenciaContabilidad = New frmTransferenciaContabilidad
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Cursor = Cursors.AppStarting
        'ModHoraExtra.actualizar()
        'Dim archivo() As String '= {"PE092019.DBF"}
        'ImportarData(archivo)
        'ActualizarData()
        ExportarData()
        'Cursor = Cursors.Default
        'MessageBox.Show("OK")
    End Sub

    Private Sub CuentaContableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CuentaContableToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaContableToolStripMenuItem1.Click
        Try
            Dim frm As frmCuentaContable = New frmCuentaContable
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub

    Private Sub ImportarCódigoSKUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarCódigoSKUToolStripMenuItem.Click
        Dim frm As New frmImportarCodigo
        frm.ShowDialog()
    End Sub

    Private Sub TercerosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TercerosToolStripMenuItem.Click
        Try
            Dim frm As frmTercero = New frmTercero
            frm.StartPosition = FormStartPosition.Manual
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema ")
        End Try
    End Sub
End Class