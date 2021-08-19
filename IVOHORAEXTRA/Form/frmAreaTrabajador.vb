Imports INTEGRACION_LN
Public Class frmAreaTrabajador
    Dim dt1 As DataTable, dt2 As DataTable, dt3 As DataTable
    Dim blnSalir As Boolean

    Private intAbuelo As Integer
    Public Property Abuelo() As Integer
        Get
            Return intAbuelo
        End Get
        Set(ByVal value As Integer)
            intAbuelo = value
        End Set
    End Property

    Private intPadre As Integer
    Public Property Padre() As Integer
        Get
            Return intPadre
        End Get
        Set(ByVal value As Integer)
            intPadre = value
        End Set
    End Property

    Private intHijo As Integer
    Public Property Hijo() As Integer
        Get
            Return intHijo
        End Get
        Set(ByVal value As Integer)
            intHijo = value
        End Set
    End Property

    Private Sub frmAreaTrabajador_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAreaTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Dim obj As New Cls_HoraExtra_LN
        dt1 = obj.ListarAreaTrabajador(1, 0, 0)
        With Me.cboNivel1
            .DisplayMember = "area"
            .ValueMember = "id"
            'RemoveHandler cboNivel1.SelectedIndexChanged, AddressOf cboNivel1_SelectedIndexChanged
            .DataSource = dt1
            'AddHandler cboNivel1.SelectedIndexChanged, AddressOf cboNivel1_SelectedIndexChanged
            .SelectedValue = Abuelo
            Me.cboNivel2.SelectedValue = Padre
            Me.cboNivel3.SelectedValue = Hijo
        End With
    End Sub

    Private Sub cboNivel1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel1.SelectedIndexChanged
        Dim obj As New Cls_HoraExtra_LN
        dt2 = obj.ListarAreaTrabajador(2, dt1.Rows(Me.cboNivel1.SelectedIndex).Item("id_usuario"), 0)
        With Me.cboNivel2
            .DisplayMember = "area"
            .ValueMember = "id"
            'RemoveHandler cboNivel2.SelectedIndexChanged, AddressOf cboNivel2_SelectedIndexChanged
            .DataSource = dt2
            'AddHandler cboNivel2.SelectedIndexChanged, AddressOf cboNivel2_SelectedIndexChanged
            .SelectedValue = 0
            Me.cboNivel3.SelectedValue = 0
        End With
    End Sub

    Private Sub cboNivel2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel2.SelectedIndexChanged
        Dim obj As New Cls_HoraExtra_LN
        dt3 = obj.ListarAreaTrabajador(3, dt2.Rows(Me.cboNivel2.SelectedIndex).Item("id_usuario"), dt1.Rows(Me.cboNivel1.SelectedIndex).Item("id_usuario"))
        With Me.cboNivel3
            .DisplayMember = "area"
            .ValueMember = "id"
            .DataSource = dt3
            .SelectedValue = 0
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboNivel1.SelectedValue = 0 Then
            MessageBox.Show("Seleccione una Area", "Area del Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboNivel1.Focus()
            Me.cboNivel1.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboNivel2.SelectedValue = 0 Then
            MessageBox.Show("Seleccione una Area", "Area del Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboNivel2.Focus()
            Me.cboNivel2.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboNivel3.SelectedValue = 0 Then
            MessageBox.Show("Seleccione una Area", "Area del Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboNivel3.Focus()
            Me.cboNivel3.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Abuelo = Me.cboNivel1.SelectedValue And Padre = Me.cboNivel2.SelectedValue And Hijo = Me.cboNivel3.SelectedValue Then
            MessageBox.Show("El Trabajador ya tiene asignado el Area seleccionada", "Area del Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboNivel1.Focus()
            Me.cboNivel1.DroppedDown = True
            blnSalir = False
            Return
        End If
    End Sub
End Class