Public Class FrmRecojoReprogramado
    Public iRecojo As Integer
    Public iTipo As Integer
    Public sFecha As String
    Public sHoraInicio As String
    Public sHoraFin As String
    Public sCliente As String
    Public sDireccion As String
    Public iRuta As Integer
    Dim bSalir As Boolean = True
    Dim iReg, j, n, m As Integer
    Public bCambio As Boolean = False
    Dim bInicio As Boolean

    Sub Inicio(ByVal i As Integer, ByVal j As Integer)
        Me.iReg = i
        Me.j = j
    End Sub

    Private Sub FrmRecojoReprogramado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.DtpFecha.Focus()
    End Sub

    Private Sub FrmRecojoReprogramado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmRecojoReprogramado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmRecojoReprogramado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bInicio = True
        Me.LblFecha.Text = sFecha
        Me.LblHoraInicio.Text = sHoraInicio
        Me.LblHoraFin.Text = sHoraFin
        Me.TxtCliente.Text = sCliente
        Me.TxtDireccion.Text = sDireccion

        Me.DtpFecha.Value = sFecha
        Me.DtpHoraInicio.Text = sHoraInicio
        Me.DtpHoraFin.Text = sHoraFin

        'Dim obj As New DtoRecojo
        'obj.Fecha = Me.DtpFecha.Text
        'Me.CboRuta.DisplayMember = "ruta"
        'Me.CboRuta.ValueMember = "id_ruta"
        'Me.CboRuta.DataSource = obj.ListarRuta(1, iTipo)
        'Me.CboRuta.SelectedValue = iRuta

        LblNumero.Text = j.ToString & "/" & iReg.ToString
        bInicio = False
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bSalir = True
        Close()
    End Sub

    Function Validar(ByVal fecha As String, ByVal hora1 As String, ByVal hora2 As String, Optional ByVal boton As Byte = 0) As Boolean
        If Not (Me.ChkFecha.Checked Or Me.ChkRuta.Checked) Then
            MessageBox.Show("Seleccione al menos un Item a Actualizar.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Return False
        End If

        If Me.ChkFecha.Checked Then
            If Convert.ToDateTime(sFecha) = Convert.ToDateTime(fecha) And Convert.ToDateTime(sHoraInicio) = Convert.ToDateTime(hora1) And Convert.ToDateTime(sHoraFin) = Convert.ToDateTime(hora2) Then
                MessageBox.Show("La Reprogramación es igual a lo Programado.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DtpFecha.Focus()
                bSalir = False
                Return False
            End If

            If Convert.ToDateTime(sFecha) > Convert.ToDateTime(fecha) Then
                MessageBox.Show("La Fecha Reprogramada es menor a la Fecha Programada.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DtpFecha.Focus()
                bSalir = False
                Return False
            End If

            If Convert.ToDateTime(hora1) = Convert.ToDateTime(hora2) And Convert.ToDateTime(sFecha) >= Convert.ToDateTime(fecha) Then
                MessageBox.Show("La Hora Listo es igual a la Hora Cierre.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DtpHoraInicio.Focus()
                bSalir = False
                Return False
            End If

            If Convert.ToDateTime(hora1) > Convert.ToDateTime(hora2) Then
                MessageBox.Show("La Hora Listo es mayor a la Hora Cierre.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DtpHoraInicio.Focus()
                bSalir = False
                Return False
            End If
        End If

        If Me.ChkRuta.Checked Then
            If Me.CboRuta.SelectedIndex = -1 Then
                MessageBox.Show("Seleccione Ruta a Reasignar.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboRuta.Focus()
                bSalir = False
                Return False
            End If

            If Me.CboRuta.SelectedValue = iRuta Then
                MessageBox.Show("La Ruta Reasignada es igual a la Asignada.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboRuta.Focus()
                bSalir = False
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        Try
            Dim sFecha2 As String = Me.DtpFecha.Text
            Dim sHoraInicio2 As String = Me.DtpHoraInicio.Text.ToString.Substring(0, 5) & IIf(DtpHoraInicio.Text.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
            Dim sHoraFin2 As String = Me.DtpHoraFin.Text.ToString.Substring(0, 5) & IIf(DtpHoraFin.Text.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")

            If Not Validar(sFecha2, sHoraInicio2, sHoraFin2) Then
                bSalir = False
                Return
            End If

            bSalir = True
            Dim obj As New DtoRecojo
            obj.Recojo = iRecojo
            obj.Fecha = sFecha2
            obj.HoraListo = sHoraInicio2
            obj.HoraCierre = sHoraFin2
            obj.Ruta = Me.CboRuta.SelectedValue

            Dim iOpcion As Integer
            If Me.ChkRuta.Checked Then
                If Not (Me.CboRuta.SelectedValue Is Nothing) Then
                    If iRuta = Me.CboRuta.SelectedValue And sFecha = Me.DtpFecha.Text Then
                        iOpcion = 0
                    Else
                        iOpcion = 1
                    End If
                Else
                    iOpcion = 2
                End If
            Else
                iOpcion = 0
            End If

            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"

            Dim iReprogramar As Integer = IIf(Me.ChkFecha.Checked, 1, 0)
            Dim iReasignar As Integer = IIf(Me.ChkRuta.Checked, 1, 0)

            obj.Reprogramar(iReprogramar, iReasignar, iOpcion)

            MessageBox.Show("Recojo Reprogramado", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bCambio = True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BtnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        bSalir = True
    End Sub

    Private Sub CboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuta.SelectedIndexChanged
        'If bInicio Then Return
        'If Not IsReference(Me.CboRuta.SelectedValue) Then
        Dim obj As New DtoRecojo
        obj.Fecha = Me.DtpFecha.Text
        obj.Ruta = Me.CboRuta.SelectedValue
        Dim dt As DataTable = obj.ListarRutaDetalle
        If dt.Rows.Count > 0 Then
            Me.TxtMovil.Text = dt.Rows(0).Item("movil").ToString.Trim
            Me.TxtChofer.Text = dt.Rows(0).Item("chofer").ToString.Trim
        Else
            Me.CboRuta.DataSource = Nothing
            Me.CboRuta.SelectedIndex = -1
            Me.TxtMovil.Text = ""
            Me.TxtChofer.Text = ""
        End If
        'End If
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        'If bInicio Then Return
        Dim obj As New DtoRecojo
        obj.Fecha = Me.DtpFecha.Text
        Me.CboRuta.DisplayMember = "ruta"
        Me.CboRuta.ValueMember = "id_ruta_unidad_transporte"
        Me.CboRuta.DataSource = obj.ListarRuta(1, iTipo).Tables(0)
        Me.CboRuta.SelectedValue = iRuta

        Me.CboRuta_SelectedIndexChanged(sender, e)
    End Sub

    Sub Reprogramar(ByVal ruta As Integer, ByVal id As Integer, ByVal fecha As String, ByVal hora1 As String, ByVal hora2 As String)
        Dim obj As New DtoRecojo
        obj.Recojo = id
        obj.Fecha = fecha
        obj.HoraListo = hora1
        obj.HoraCierre = hora2
        obj.Ruta = Me.CboRuta.SelectedValue

        Dim iOpcion As Integer
        If Me.ChkRuta.Checked Then
            If Not (Me.CboRuta.SelectedValue Is Nothing) Then
                If ruta = Me.CboRuta.SelectedValue And sFecha = Me.DtpFecha.Text Then
                    iOpcion = 0
                Else
                    iOpcion = 1
                End If
            Else
                iOpcion = 2
            End If
        Else
            iOpcion = 0
        End If

        Dim iReprogramar As Integer = IIf(Me.ChkFecha.Checked, 1, 0)
        Dim iReasignar As Integer = IIf(Me.ChkRuta.Checked, 1, 0)

        obj.Usuario = dtoUSUARIOS.IdLogin
        obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
        obj.Reprogramar(iReprogramar, iReasignar, iOpcion)
    End Sub

    Private Sub BtnSiaTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiaTodo.Click
        Dim dlgRespuesta As DialogResult

        Dim sFecha2 As String = Me.DtpFecha.Text
        Dim sHoraInicio2 As String = Me.DtpHoraInicio.Text.ToString.Substring(0, 5) & IIf(DtpHoraInicio.Text.ToString.Substring(7, 1) = "A", " am", " pm")
        Dim sHoraFin2 As String = Me.DtpHoraFin.Text.ToString.Substring(0, 5) & IIf(DtpHoraFin.Text.ToString.Substring(7, 1) = "A", " am", " pm")

        dlgRespuesta = MessageBox.Show("¿Está Seguro de Actualizar los Recojos Seleccionados?", "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            If iReg > 1 Then
                If Not (Me.ChkFecha.Checked Or Me.ChkRuta.Checked) Then
                    MessageBox.Show("Seleccione al menos un Item a Actualizar.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Return
                End If

                If Me.ChkFecha.Checked Then
                    If Convert.ToDateTime(sFecha) > Convert.ToDateTime(sFecha2) Then
                        MessageBox.Show("La Fecha Reprogramada es menor a la Fecha Programada.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DtpFecha.Focus()
                        bSalir = False
                        Return
                    End If
                End If

                If Me.ChkRuta.Checked Then
                    If Me.CboRuta.SelectedIndex = -1 Then
                        MessageBox.Show("Seleccione Ruta a Reasignar.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.CboRuta.Focus()
                        bSalir = False
                        Return
                    End If
                End If
            Else
                If Not Validar(sFecha2, sHoraInicio2, sHoraFin2) Then
                    bSalir = False
                    Return
                End If
            End If

            Dim i As Integer
            For i = 1 To aRecojo.Length - 1
                Reprogramar(aRecojo(i).ruta, aRecojo(i).recojo, sFecha2, sHoraInicio2, sHoraFin2)
            Next

            Dim s As String = IIf(i - 1 = 1, "El Recojo ha sido Reprogramado.", "Los Recojos han sido Reprogramados.")
            MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bCambio = True
            bSalir = True
        End If
    End Sub

    Private Sub ChkRuta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRuta.CheckedChanged
        GrbB.Enabled = ChkRuta.Checked
    End Sub

    Private Sub ChkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFecha.CheckedChanged
        GrbA.Enabled = ChkFecha.Checked
    End Sub
End Class