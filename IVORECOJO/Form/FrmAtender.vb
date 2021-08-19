Public Class FrmAtender
    Dim iProceso, iRecojo, i, j, n, m As Integer
    Dim bSalir As Boolean = True
    Dim lista() As Integer
    Public bCambio As Boolean = False
    Dim dt As New DataTable
    Dim dtAgencia As DataTable
    Dim bInicio As Boolean
    Sub Limpiar()
        'Dim sFechaHoraServidor = FechaServidor()
        Dim sFecha As String = FechaServidor()
        Me.LblFecha.Text = sFecha
        'Me.lbl.Value = sFechaHoraServidor
        'Me.DtpHora2.Value = sFechaHoraServidor

        Me.TxtAtendidoPor.Text = ""
        Me.TxtObservacion.Text = ""
        Me.CboIncidencia.SelectedValue = 0
        Me.TxtObservacion2.Text = ""
        Me.CboTipo.SelectedIndex = 0
    End Sub

    Sub Inicio(ByVal recojo As Integer, ByVal idcliente As Integer, ByVal cliente As String, ByVal contacto As String, ByVal direccion As String, ByVal proceso As Integer, ByVal lista() As Integer, ByVal i As Integer, ByVal j As Integer)
        iRecojo = recojo
        iProceso = proceso
        Me.TxtCliente.Tag = idcliente
        Me.TxtCliente.Text = cliente
        Me.TxtContacto.Text = contacto
        Me.TxtDireccion.Text = direccion
        Me.lista = lista.Clone
        Me.i = i
        Me.j = j
    End Sub

    Private Sub RbtAtendido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtAtendido.CheckedChanged
        Me.PnlAtendido.Visible = True
        Me.PnlNoAtendido.Visible = False
        Me.TxtAtendidoPor.Focus()
    End Sub

    Private Sub RbtNoAtendido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNoAtendido.CheckedChanged
        Me.PnlAtendido.Visible = False
        Me.PnlNoAtendido.Visible = True
        Me.CboTipo.Focus()
    End Sub

    Sub Cargar()
        Try
            Dim obj As New DtoRecojo
            dt = obj.ListarEstado(Recojo.ATENDIDO)
            Me.CboIncidencia.DataSource = dt
            Me.CboIncidencia.DisplayMember = "check_point_recojo"
            Me.CboIncidencia.ValueMember = "id_checkpoint_recojo"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub FrmAtender_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ChkParcial.Focus()
    End Sub

    Private Sub FrmAtender_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            e.Cancel = True
            bSalir = True
        End If
    End Sub

    Private Sub FrmAtender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Function Validar() As Boolean
        If Me.RbtAtendido.Checked Then
            'If Me.CboCiudad.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Ciudad Destino", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.CboCiudad.Focus()
            '    Return False
            'End If

            'If Me.CboAgencia.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Agencia Destino", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.CboAgencia.Focus()
            '    Return False
            'End If

            'If Me.CboTipoComprobante.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Tipo de Comprobante", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.CboTipoComprobante.Focus()
            '    Return False
            'End If

            'If Val(Me.TxtBulto.Text.Trim) = 0 Then
            '    MessageBox.Show("Ingrese Nº de Bultos.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.TxtBulto.Focus()
            '    Return False
            'End If

            If Me.TxtAtendidoPor.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese los Nombres de la Persona que Atendió.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtAtendidoPor.Text = ""
                Me.TxtAtendidoPor.Focus()
                Return False
            End If
        Else
            If Me.CboTipo.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Tipo de No Atención.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipo.Focus()
                Return False
            End If

            If Me.CboIncidencia.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Motivo de No Atención.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboIncidencia.Focus()
                Return False
            End If

            If Me.TxtObservacion2.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Observación.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtObservacion2.Text = ""
                Me.TxtObservacion2.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Sub Atender()
        Try
            Dim obj As New DtoRecojo
            obj.Recojo = iRecojo
            obj.AtendidoPor = Me.TxtAtendidoPor.Text.Trim
            obj.Observacion = Me.TxtObservacion.Text.Trim
            'obj.FechaAtencion = Me.DtpFecha.Text & " " & Me.DtpHora.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora.Text.ToString.Substring(7, 1) = "A", " am", " pm")
            obj.Atendido = 1
            obj.Parcial = IIf(Me.ChkParcial.Checked, 1, 0)
            obj.Estado = RECOJO.ATENDIDO
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            'obj.Ciudad = Me.CboCiudad.SelectedValue
            'obj.Agencia = Me.CboAgencia.SelectedValue
            'obj.TipoComprobante = Me.CboTipoComprobante.SelectedValue
            'obj.Serie = Me.TxtSerie.Text.Trim
            'obj.Numero = Me.TxtNumero.Text.Trim
            'obj.Guia = Me.TxtGuia.Text.Trim
            obj.Cliente = Me.TxtCliente.Tag
            obj.AgenciaOrigen = dtoUSUARIOS.iIDAGENCIAS
            obj.Proceso = iProceso
            'obj.Cantidad = Val(Me.TxtBulto.Text)
            obj.Atender()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TxtAtendidoPor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAtendidoPor.Enter
        Me.TxtAtendidoPor.SelectAll()
    End Sub

    Private Sub TxtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObservacion.Enter
        Me.TxtObservacion.SelectAll()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bSalir = True
    End Sub

    Sub Incidencia()
        Try
            Dim obj As New DtoRecojo
            obj.Recojo = iRecojo
            obj.Observacion = Me.TxtObservacion2.Text.Trim
            obj.FechaAtencion = Me.DtpFecha2.Text & " " & Me.DtpHora2.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora2.Text.ToString.Substring(7, 1) = "A", " am", " pm")
            obj.Atendido = 0
            obj.Tipo = Me.cboTipo.SelectedIndex
            obj.Incidencia = Me.CboIncidencia.SelectedValue
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.GenerarIncidencia()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Atender(ByVal id As Integer)
        Try
            Dim obj As New DtoRecojo
            obj.Recojo = id
            obj.AtendidoPor = Me.TxtAtendidoPor.Text.Trim
            obj.Observacion = Me.TxtObservacion.Text.Trim
            'obj.FechaAtencion = Me.DtpFecha.Text & " " & Me.DtpHora.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora.Text.ToString.Substring(7, 1) = "A", " am", " pm")
            obj.Atendido = 1
            obj.Parcial = IIf(Me.ChkParcial.Checked, 1, 0)
            obj.Estado = RECOJO.ATENDIDO
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"

            'obj.Ciudad = Me.CboCiudad.SelectedValue
            'obj.Agencia = Me.CboAgencia.SelectedValue
            'obj.TipoComprobante = Me.CboTipoComprobante.SelectedValue
            'obj.Serie = Me.TxtSerie.Text.Trim
            'obj.Numero = Me.TxtNumero.Text.Trim
            'obj.Guia = Me.TxtGuia.Text.Trim
            'obj.Cliente = Me.TxtCliente.Tag
            obj.AgenciaOrigen = dtoUSUARIOS.iIDAGENCIAS
            obj.Proceso = iProceso
            'obj.Cantidad = Me.TxtBulto.Text
            obj.Atender()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Incidencia(ByVal id As Integer)
        Try
            Dim obj As New DtoRecojo
            obj.Recojo = id
            obj.Observacion = Me.TxtObservacion2.Text.Trim
            obj.FechaAtencion = Me.DtpFecha2.Text & " " & Me.DtpHora2.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora2.Text.ToString.Substring(7, 1) = "A", " am", " pm")
            obj.Atendido = 0
            obj.Tipo = cboTipo.SelectedIndex
            obj.Incidencia = Me.CboIncidencia.SelectedValue
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.GenerarIncidencia()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BtnSiaTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiaTodo.Click
        Try
            Dim dlgRespuesta As DialogResult
            Dim sRespuesta As String

            If Me.RbtAtendido.Checked Then
                sRespuesta = "¿Está Seguro de Atender los Recojos Seleccionados?"
            Else
                sRespuesta = "¿Está Seguro de No Atender los Recojos Seleccionados?"
            End If

            dlgRespuesta = MessageBox.Show(sRespuesta, "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                If Me.RbtNoAtendido.Checked Then
                    If Not Validar() Then
                        bSalir = False
                        Return
                    End If

                    Dim i As Integer
                    For i = 1 To lista.Length - 1
                        Incidencia(lista(i))
                    Next
                    Dim s As String = IIf(i = 0, "El Recojo no fue Atendido.", "Los Recojos no fueron Atendidos.")
                    MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = True
                    bCambio = True
                Else
                    If Not Validar() Then
                        bSalir = False
                        Return
                    End If

                    Dim i As Integer
                    For i = 1 To lista.Length - 1
                        Atender(lista(i))
                    Next
                    Dim s As String = IIf(i = 0, "El Recojo ha sido Atendido.", "Los Recojos han sido Atendidos.")
                    MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bCambio = True
                    bSalir = True
                End If
            Else
                bSalir = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        Try
            If Not Validar() Then
                bSalir = False
                Return
            End If

            If Me.RbtNoAtendido.Checked Then
                Incidencia()
                m += 1
            Else
                Me.Cursor = Cursors.AppStarting
                Atender()
                n += 1
            End If
            Mensaje()
            bCambio = True

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Mensaje()
        Dim s As String = ""
        If i = j And n > 0 And m = 0 Then
            s = IIf(n = 1, "El Recojo ha sido Atendido.", "Los Recojos han sido Atendidos.")
            MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf i = j And m > 0 And n = 0 Then
            s = IIf(m = 1, "El Recojo no ha sido Atendido.", "Los Recojos no fueron Atendidos.")
            MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf i = j And n + m > 0 Then
            s = IIf(n + m = 1, "Recojo Actualizado.", "Recojos Actualizados.")
            MessageBox.Show(s, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        If n + m > 0 And i = j Then
            Mensaje()
        End If
    End Sub

    Private Sub CboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If bInicio Then Return
        Dim iTipo As Integer = 0
        If cboTipo.SelectedIndex = 1 Then
            iTipo = 2
        ElseIf cboTipo.SelectedIndex = 2 Then
            iTipo = 3
        End If
        Dim s As String = "tipo=" & iTipo & " or tipo=0"
        dt.DefaultView.RowFilter = s
    End Sub

    Private Sub FrmAtender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True
            Limpiar()
            LblNumero.Text = j.ToString & "/" & i.ToString

            Inicio()

            Cargar()
            bInicio = False
            CboTipo_SelectedIndexChanged(sender, e)
            CboCiudad_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Inicio()
        Try
            'Dim ds As DataSet = DtoRecojo.InicioAtendido
            'Me.CboCiudad.DataSource = ds.Tables(0)
            'Me.CboCiudad.DisplayMember = "nombre_unidad"
            'Me.CboCiudad.ValueMember = "idunidad_agencia"
            'Me.CboCiudad.SelectedValue = 0

            'dtAgencia = ds.Tables(1)
            'Me.CboAgencia.DataSource = dtAgencia
            'Me.CboAgencia.DisplayMember = "nombre_agencia"
            'Me.CboAgencia.ValueMember = "idagencias"
            'Me.CboAgencia.SelectedValue = 0

            'Me.CboTipoComprobante.DataSource = ds.Tables(2)
            'Me.CboTipoComprobante.DisplayMember = "tipo_comprobante"
            'Me.CboTipoComprobante.ValueMember = "idtipo_comprobante"
            'Me.CboTipoComprobante.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub CboTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If bInicio Then Return
        'Select Case CboTipoComprobante.SelectedValue
        '    Case 0
        '        Me.TxtGuia.Text = ""
        '        Me.TxtSerie.Text = ""
        '        Me.TxtNumero.Text = ""
        '        Me.TxtGuia.ReadOnly = True
        '        Me.TxtSerie.ReadOnly = True
        '        Me.TxtNumero.ReadOnly = True
        '    Case 1, 2
        '        Me.TxtGuia.Text = ""
        '        Me.TxtGuia.Visible = False
        '        Me.TxtSerie.Visible = True
        '        Me.TxtNumero.Visible = True
        '        Me.TxtSerie.ReadOnly = False
        '        Me.TxtNumero.ReadOnly = False
        '    Case Else
        '        Me.TxtSerie.Text = ""
        '        Me.TxtNumero.Text = ""
        '        Me.TxtGuia.Visible = True
        '        Me.TxtSerie.Visible = False
        '        Me.TxtNumero.Visible = False
        '        Me.TxtGuia.ReadOnly = True
        'End Select
    End Sub

    Private Sub CboCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If bInicio Then Return
        'Dim s As String = "idunidad_agencia=" & CboCiudad.SelectedValue & " or idunidad_agencia=0"
        'dtAgencia.DefaultView.RowFilter = s
    End Sub

    Private Sub TxtSerie_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.TxtSerie.SelectAll()
    End Sub

    Private Sub TxtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Val(Me.TxtSerie.Text) > 0 Then
        'Me.TxtSerie.Text = Me.TxtSerie.Text.PadLeft(3, "0")
        'End If
    End Sub

    Private Sub TxtGuia_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.TxtGuia.SelectAll()
    End Sub

    Private Sub TxtGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtGuia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Val(Me.TxtGuia.Text) > 0 Then
        '    Me.TxtGuia.Text = Me.TxtGuia.Text.PadLeft(13, "0")
        'End If
    End Sub

    Private Sub TxtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.TxtNumero.SelectAll()
    End Sub

    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Val(Me.TxtNumero.Text) > 0 Then
        '    Me.TxtNumero.Text = Me.TxtNumero.Text.PadLeft(7, "0")
        'End If
    End Sub

    Private Sub TxtBulto_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.TxtBulto.SelectAll()
    End Sub

    Private Sub TxtAtendidoPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAtendidoPor.TextChanged

    End Sub

    Private Sub TxtBulto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ChkParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkParcial.CheckedChanged

    End Sub

    Private Sub cboTipo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub
End Class