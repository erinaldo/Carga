Imports System.Windows.Forms

Public Class frmPlantillaFiltros

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Dim List As Collection
    Private Sub frmPlantillaFiltros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        List = Nothing
        List = New Collection
        List.Add(New ModuUtil.ListViewCabecera("ID", 20, HorizontalAlignment.Center, 10))
        List.Add(New ModuUtil.ListViewCabecera("AGENCIA", 130, HorizontalAlignment.Left, 10))
        List.Add(New ModuUtil.ListViewCabecera("ID", 20, HorizontalAlignment.Left, 10))
        List.Add(New ModuUtil.ListViewCabecera("CONCESIONARIO", 130, HorizontalAlignment.Left, 10))
        'rst = Nothing
        ListCtrlDatos.Clear()
        ModuUtil.LlenarCabeceraLista(ListCtrlDatos, List)

        'Dim item As New ListViewItem
        'item.SubItems.Add(Me.txtFiltroDatos.Text)
        'item.SubItems.Add(Me.cmbListaDatos.SelectedItem)
        'ListCtrlDatos.Items.AddRange(New ListViewItem() {item})

    End Sub
End Class
