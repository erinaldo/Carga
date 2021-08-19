Imports INTEGRACION_LN
Public Class FrmAgregarAcuerdoCliente
    Dim blnSalir As Boolean = True
#Region "Propiedades"
    Private intOpcion As Integer
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property

    Private intIDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return intIDCliente
        End Get
        Set(ByVal value As Integer)
            intIDCliente = value
        End Set
    End Property
    Private strCliente As String
    Public Property Cliente() As String
        Get
            Return strCliente
        End Get
        Set(ByVal value As String)
            strCliente = value
        End Set
    End Property
    Private intIDProducto As Integer
    Public Property IDProducto() As Integer
        Get
            Return intIDProducto
        End Get
        Set(ByVal value As Integer)
            intIDProducto = value
        End Set
    End Property
    Private strProducto As String
    Public Property Producto() As String
        Get
            Return strProducto
        End Get
        Set(ByVal value As String)
            strProducto = value
        End Set
    End Property
    Private intSubcuenta As Integer
    Public Property Subcuenta() As Integer
        Get
            Return intSubcuenta
        End Get
        Set(ByVal value As Integer)
            intSubcuenta = value
        End Set
    End Property
    Private intOrigen As Integer
    Public Property Origen() As Integer
        Get
            Return intOrigen
        End Get
        Set(ByVal value As Integer)
            intOrigen = value
        End Set
    End Property
    Private intDestino As Integer
    Public Property Destino() As Integer
        Get
            Return intDestino
        End Get
        Set(ByVal value As Integer)
            intDestino = value
        End Set
    End Property
    Private intTipoTarifa As Integer
    Public Property TipoTarifa() As Integer
        Get
            Return intTipoTarifa
        End Get
        Set(ByVal value As Integer)
            intTipoTarifa = value
        End Set
    End Property
    Private intRetorno As Integer
    Public Property Retorno() As Integer
        Get
            Return intRetorno
        End Get
        Set(ByVal value As Integer)
            intRetorno = value
        End Set
    End Property
    Private intTiempo As Integer
    Public Property Tiempo() As Integer
        Get
            Return intTiempo
        End Get
        Set(ByVal value As Integer)
            intTiempo = value
        End Set
    End Property

#End Region
    Private Sub FrmAgregarAcuerdoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmAgregarAcuerdoCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim obj As New UtilData_LN
        Dim dt As DataTable

        dt = obj.ListarSubcuenta(intIDCliente)
        With cboSubcuenta
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "CENTRO_COSTO"
            .ValueMember = "IDCENTRO_COSTO"
            .SelectedValue = 999
        End With

        dt = obj.ListarCiudad(1)
        With cboOrigen
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
        End With

        With cboDestino
            .DataSource = Nothing
            .DataSource = dt.Copy
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
        End With

        Dim utilData As New UtilData_LN
        utilData.cargarCombos("t_tipotarifa", cboTipoTarifa, False)

        Me.lblCliente.Text = Cliente
        Me.lblProducto.Text = Producto

        If Opcion = 2 Then
            Me.cboSubcuenta.SelectedValue = Subcuenta
            Me.cboOrigen.SelectedValue = Origen
            Me.cboDestino.SelectedValue = Destino
            Me.cboTipoTarifa.SelectedValue = TipoTarifa
            Me.chkRetorno.Checked = IIf(Retorno = 1, True, False)
            Me.txtDiasTransito.Text = Tiempo
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboSubcuenta.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Subcuenta", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboSubcuenta.Focus()
            Return
        End If
        If Me.cboOrigen.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Ciudad Origen", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboOrigen.Focus()
            Return
        End If
        If Me.cboDestino.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Ciudad Destino", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboDestino.Focus()
            Return
        End If
        If Me.cboOrigen.SelectedValue = Me.cboDestino.SelectedValue Then
            MessageBox.Show("La Ciudad Origen y Destino no pueden ser iguales", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboOrigen.Focus()
            Return
        End If
        If Me.cboTipoTarifa.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Tarifa", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboTipoTarifa.Focus()
            Return
        End If
        If Val(Me.txtDiasTransito.Text) <= 0 Then
            MessageBox.Show("Ingrese Días de Tránsito", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.txtDiasTransito.Focus()
            Return
        End If
    End Sub

    Private Sub txtDiasTransito_Enter(sender As Object, e As System.EventArgs) Handles txtDiasTransito.Enter
        Me.txtDiasTransito.SelectAll()
    End Sub

    Private Sub cboSubcuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboSubcuenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboOrigen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboDestino_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestino.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtDiasTransito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasTransito.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub FrmAgregarAcuerdoCliente_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.cboSubcuenta.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub cboProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoTarifa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoTarifa.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub chkRetorno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chkRetorno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
End Class