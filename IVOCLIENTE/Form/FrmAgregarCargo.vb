Imports INTEGRACION_LN
Public Class FrmAgregarCargo
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
    Private intSubcuenta As Integer
    Public Property Subcuenta() As Integer
        Get
            Return intSubcuenta
        End Get
        Set(ByVal value As Integer)
            intSubcuenta = value
        End Set
    End Property
    Private intCargo As Integer
    Public Property Cargo() As Integer
        Get
            Return intCargo
        End Get
        Set(ByVal value As Integer)
            intCargo = value
        End Set
    End Property

#End Region

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboSubcuenta.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Subcuenta", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboSubcuenta.Focus()
            Return
        End If
        If Me.cboCargo.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Cargo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Me.cboCargo.Focus()
            Return
        End If
    End Sub

    Private Sub FrmAgregarCargo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmAgregarCargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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

        Dim obj2 As New Cls_ClienteTipoFacturacion_LN
        dt = obj2.ListarCargos
        With cboCargo
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "cargo"
            .ValueMember = "id"
            .SelectedValue = 0
        End With

        Me.lblCliente.Text = Cliente
        If Opcion = 2 Then
            Me.cboSubcuenta.SelectedValue = Subcuenta
            Me.cboCargo.SelectedValue = Cargo
        End If
    End Sub

    Private Sub cboSubcuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboSubcuenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboCargo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCargo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

    End Sub
End Class