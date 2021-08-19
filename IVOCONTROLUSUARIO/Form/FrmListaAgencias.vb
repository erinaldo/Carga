Public Class FrmListaAgencias
    Private iUsuario As Integer

    Public WriteOnly Property Usuario() As Integer
        Set(ByVal value As Integer)
            iUsuario = value
        End Set
    End Property

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub

    Private Sub FrmListaAgencias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUsuario As New dtoCONTROLUSUARIOS
        dgvAgencia.DataSource = objUsuario.GET_AGENCIA_USUARIO(iUsuario)
        ConfiguraGrid()
        If Me.dgvAgencia.Rows.Count > 0 Then
            Me.dgvAgencia.Rows(0).Selected = True
            Me.dgvAgencia.Select()
        End If
    End Sub

    Private Sub ConfiguraGrid()
        With dgvAgencia
            .Columns(0).Width = 100
            '.Columns(1).Width = 300
            .Columns(0).HeaderText = "Id"
            .Columns(1).HeaderText = "Nombre"
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub
End Class