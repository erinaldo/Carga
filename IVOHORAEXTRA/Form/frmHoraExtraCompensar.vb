Imports INTEGRACION_LN

Public Class frmHoraExtraCompensar
    Dim blnSalir As Boolean = True
    Public dgv As DataGridView

    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
        End Set
    End Property

    Private intIDDet As Integer
    Public Property IDDet() As Integer
        Get
            Return intIDDet
        End Get
        Set(ByVal value As Integer)
            intIDDet = value
        End Set
    End Property

    Private strHoras As String
    Public Property Horas() As String
        Get
            Return strHoras
        End Get
        Set(ByVal value As String)
            strHoras = value
        End Set
    End Property

    Private strCodigo As String
    Public Property Codigo() As String
        Get
            Return strCodigo
        End Get
        Set(ByVal value As String)
            strCodigo = value
        End Set
    End Property

    Private Sub frmHoraExtraCompensar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmHoraExtraCompensar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intHoras As Integer, intMinutos As Integer
        intHoras = Val(strHoras.Substring(0, 2))
        intMinutos = Val(strHoras.Substring(3, 2))

        Me.lblVacaciones.Visible = False
        Me.cboHoras.Items.Clear()
        Me.cboHoras.Items.Add("(SELECCIONE)")
        For i As Integer = 1 To intHoras
            Me.cboHoras.Items.Add(Format(i, "00") + ":00")
            If i < intHoras Then
                Me.cboHoras.Items.Add(Format(i, "00") + ":30")
            End If
        Next
        If intMinutos > 0 Then
            Me.cboHoras.Items.Add(Format(intHoras, "00") + ":30")
        End If
        Me.cboHoras.SelectedIndex = 0
        Me.cboTipoCompensacion.SelectedIndex = 0

        ListarTipoCompensacion()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Me.dtpFecha.Checked Then
            MessageBox.Show("Seleccione la fecha de compensación", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            blnSalir = False
            Return
        End If

        If Me.lblVacaciones.Visible Then
            MessageBox.Show("El Trabajador tiene vacaciones para la fecha seleccionada", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            blnSalir = False
            Return
        End If

        If Me.cboTipoCompensacion.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Compensación", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoCompensacion.DroppedDown = True
            Me.cboTipoCompensacion.Focus()
            blnSalir = False
            Return
        End If

        If Me.cboTipoCompensacion.SelectedIndex = 1 Then
            Dim strPeriodoActual As String = PeriodoActual()
            Dim strPeriodo As String = Cls_HoraExtra_LN.PeriodoActual(Me.dtpFecha.Value.ToShortDateString)
            If strPeriodoActual <> strPeriodo Then
                MessageBox.Show("No puede pagar HHEE en efectivo fuera de su período", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoCompensacion.Focus()
                Me.cboTipoCompensacion.DroppedDown = True
                Return
            End If
        End If

        If Me.cboHoras.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Horas a Compensar", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboHoras.DroppedDown = True
            Me.cboHoras.Focus()
            blnSalir = False
            Return
        End If

        If Me.cboHoras.Text = "00:30" Then
            MessageBox.Show("La Compensación debe ser a partir de 1 hora", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboHoras.DroppedDown = True
            Me.cboHoras.Focus()
            blnSalir = False
            Return
        End If

        Dim dblEfectivo As Double = Cls_HoraExtra_LN.ValorHE(Me.lblEfectivo.Text)
        Dim dblDescanso As Double = Cls_HoraExtra_LN.ValorHE(Me.lblDescanso.Text)
        Dim dblHoras As Double = Cls_HoraExtra_LN.ValorHE(Me.cboHoras.Text)
        Dim intTipoCompensacion As Integer = Me.cboTipoCompensacion.SelectedIndex

        If dblEfectivo + dblDescanso > 0 Then
            Dim strMensaje As String = ""
            If intTipoCompensacion = 1 Then
                If dblHoras > dblEfectivo Then
                    strMensaje = "Las HHEE por compensar " & dblHoras & " no puede ser mayor a las HHEE disponibles " & dblEfectivo
                    MessageBox.Show(strMensaje, "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Return
                End If
            Else
                If dblHoras > dblDescanso Then
                    strMensaje = "Las HHEE por compensar " & dblHoras & " no puede ser mayor a las HHEE disponibles " & dblDescanso
                    MessageBox.Show(strMensaje, "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Return
                End If
            End If

            Dim intTieneSolicitud As Integer = Cls_HoraExtra_LN.TieneSolicitudCompensado(ID, IDDet)
            If intTieneSolicitud = 1 Then
                MessageBox.Show("Existe una solicitud con el estado pendiente", "Compensar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpFecha.Focus
                blnSalir = False
                Return
            End If
        End If
    End Sub

    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cboHoras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHoras.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Dim obj As New Cls_HoraExtra_LN

        'Dim dt As DataTable = obj.ListarHECompensada(Codigo, Me.dtpFecha.Value.ToShortDateString)
        'If dt.Rows.Count > 0 Then
        '    Dim strHorasCompensadas As String = SumaHoras(dt, "horas")
        '    Me.lblHorasCompensadas.Text = strHorasCompensadas
        'Else
        '    Me.lblHorasCompensadas.Text = "00:00"
        'End If

        Dim strPeriodo As String = Me.dtpFecha.Value.Year.ToString & Me.dtpFecha.Value.Month.ToString.PadLeft(2, "0")
        Dim blnVacaciones As Boolean = obj.EsVacaciones(strPeriodo, Codigo)
        Me.lblVacaciones.Visible = blnVacaciones

    End Sub

    Private Sub cboHoras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHoras.SelectedIndexChanged
        'Dim strHora As String, strMinuto As String
        'Dim strHoraC As String, strMinutoC As String
        'Dim strTotal As String
        'Dim intHora As Integer, intMinuto As Integer

        'strHora = Me.cboHoras.Text.Substring(0, 2)
        'strMinuto = Me.cboHoras.Text.Substring(3, 2)

        'strHoraC = Me.lblHorasCompensadas.Text.Substring(0, 2)
        'strMinutoC = Me.lblHorasCompensadas.Text.Substring(3, 2)

        'If Val(strMinuto) = 30 And Val(strMinutoC) = 30 Then
        '    intHora = 1
        '    intMinuto = 0
        'End If
        'intHora += Val(strHora) + Val(strHoraC)
        'intMinuto += Val(strMinuto) + Val(strMinutoC)

        'strTotal = intHora.ToString.PadLeft(2, "0") & ":" & intMinuto.ToString.PadLeft(2, "0")
        'Me.lblTotal.Text = strTotal
    End Sub

    Sub ListarTipoCompensacion()
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarTipoCompensacion(ID, IDDet)
        Dim intEfectivo As Integer = 0, intDescanso As Integer = 0

        Dim dblEfectivo As Double = 0, dblDescanso As Double = 0
        If dgv.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells("idtipo_compensacion").Value = 1 Then
                    dblEfectivo += Cls_HoraExtra_LN.ValorHE(row.Cells("horas").Value)
                End If
                If row.Cells("idtipo_compensacion").Value = 2 Then
                    dblDescanso += Cls_HoraExtra_LN.ValorHE(row.Cells("horas").Value)
                End If
            Next
        End If

        Dim dblEfectivo1 As Double = 0, dblDescanso1 As Double = 0
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If row("tipo_compensacion") = 1 Then
                    'Me.lblEfectivo.Text = row("horas")
                    dblEfectivo1 += Cls_HoraExtra_LN.ValorHE(row("horas"))
                    intEfectivo = 1
                End If
                If row("tipo_compensacion") = 2 Then
                    'Me.lblDescanso.Text = row("horas")
                    dblDescanso1 += Cls_HoraExtra_LN.ValorHE(row("horas"))
                    intDescanso = 1
                End If
            Next
            dblEfectivo = IIf(dblEfectivo1 - dblEfectivo < 0, dblEfectivo1, dblEfectivo1 - dblEfectivo)
            dblDescanso = IIf(dblDescanso1 - dblDescanso < 0, dblDescanso1, dblDescanso1 - dblDescanso)
            Me.lblEfectivo.Text = Cls_HoraExtra_LN.ValorCadena(dblEfectivo)
            Me.lblDescanso.Text = Cls_HoraExtra_LN.ValorCadena(dblDescanso)
        Else
            Me.lblEfectivo.Text = "00:00"
            Me.lblDescanso.Text = "00:00"
        End If

        If intEfectivo = 1 And intDescanso = 0 Then
            Me.cboTipoCompensacion.SelectedIndex = 1
            Me.cboTipoCompensacion.Enabled = False
        ElseIf intDescanso = 1 And intEfectivo = 0 Then
            Me.cboTipoCompensacion.SelectedIndex = 2
            Me.cboTipoCompensacion.Enabled = False
        Else
            Me.cboTipoCompensacion.SelectedIndex = 0
            Me.cboTipoCompensacion.Enabled = True
        End If
    End Sub
End Class