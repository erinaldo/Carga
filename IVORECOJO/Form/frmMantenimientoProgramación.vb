Public Class frmMantenimientoProgramacion
    Dim blnSalir As Boolean

    Private intOpcion As Integer

#Region "Propiedad"
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property

    Private intDia As Integer
    Public Property Dia() As Integer
        Get
            Return intDia
        End Get
        Set(ByVal value As Integer)
            intDia = value
        End Set
    End Property

    Private strHoraListo As String
    Public Property HoraListo() As String
        Get
            Return strHoraListo
        End Get
        Set(ByVal value As String)
            strHoraListo = value
        End Set
    End Property

    Private strHoraCierre As String
    Public Property HoraCierre() As String
        Get
            Return strHoraCierre
        End Get
        Set(ByVal value As String)
            strHoraCierre = value
        End Set
    End Property

    Private intCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return intCantidad
        End Get
        Set(ByVal value As Integer)
            intCantidad = value
        End Set
    End Property

    Private dblPeso As Double
    Public Property Peso() As Double
        Get
            Return dblPeso
        End Get
        Set(ByVal value As Double)
            dblPeso = value
        End Set
    End Property

    Private dblVolumen As Double
    Public Property Volumen() As Double
        Get
            Return dblVolumen
        End Get
        Set(ByVal value As Double)
            dblVolumen = value
        End Set
    End Property

#End Region
    Private Sub frmMantenimientoProgramacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMantenimientoProgramacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        If intOpcion = 1 Then
            Me.cboDia.SelectedIndex = 0
        Else
            Me.cboDia.SelectedIndex = intDia
            Me.DtpHora1.Text = strHoraListo
            Me.DtpHora2.Text = strHoraCierre
            Me.txtBultos.Text = IIf(intCantidad = 0, "", intCantidad)
            Me.txtPeso.Text = IIf(dblPeso = 0, "", Format(dblPeso, "0.00"))
            Me.txtVolumen.Text = IIf(dblVolumen = 0, "", Format(dblVolumen, "0.00"))
        End If
        Me.cboDia.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboDia.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el día", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboDia.Focus()
            Me.cboDia.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Convert.ToDateTime(DtpHora2.Text) <= Convert.ToDateTime(DtpHora1.Text) Then
            MessageBox.Show("La Hora Listo debe ser menor a la Hora Cierre.", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpHora1.Focus()
            blnSalir = False
            Return
        End If

        Dim iTiempo As Integer = dtrecojo.TiempoListoCierre
        Dim tTiempo As TimeSpan = Convert.ToDateTime(Me.DtpHora2.Text) - Convert.ToDateTime(Me.DtpHora1.Text)
        Dim iDiferencia As Integer = tTiempo.Minutes + (tTiempo.Hours * 60)

        If iDiferencia < iTiempo Then
            MessageBox.Show("La Diferencia entre la Hora Listo y Cierre " & vbCrLf & "Debe ser Mayor o Igual a " & iTiempo & " Minutos.", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpHora1.Focus()
            blnSalir = False
            Return
        End If

        If Val(Me.txtPeso.Text) = 0 Then
            MessageBox.Show("Ingrese el Peso", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPeso.Focus()
            Me.txtPeso.SelectAll()
            blnSalir = False
            Return
        End If
    End Sub

    Private Sub cboDia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDia.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub DtpHora1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub DtpHora2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtBultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBultos.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumero(e.KeyChar)
        End If
    End Sub

    Private Sub txtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, Me.txtPeso.Text)
        End If
    End Sub

    Private Sub txtVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, Me.txtVolumen.Text)
        End If
    End Sub
End Class