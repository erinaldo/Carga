Imports INTEGRACION_LN
Public Class Frm_BuscarCliente
    Private lObj_ClsBuscarClienteLN As Cls_BuscarClienteLN

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        S_Buscar()
    End Sub




    Private Sub S_Buscar()

        Dim lclsUtilitarios As Cls_Utilitarios
        Dim lStr_Busqueda As String
        lObj_ClsBuscarClienteLN = New Cls_BuscarClienteLN

        lStr_Busqueda = Me.txtBuscador.Text.Trim
        If flagBusquedas <> 6 Then

            If Len(lStr_Busqueda) < 2 Then
                MsgBox("Debe Ingresar almenos 2 Digitos")
                Return
            End If
        End If
        lStr_Busqueda = lStr_Busqueda + "%"

        Windows.Forms.Cursor.Show()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor()
        Me.DgvBuscador.DataSource = lObj_ClsBuscarClienteLN.F_BuscarCliente_LN(lStr_Busqueda)
        btnAceptar.Focus()

        lclsUtilitarios = New Cls_Utilitarios
        With lclsUtilitarios
            .FormatDataGridView(Me.DgvBuscador)
        End With
        lclsUtilitarios = Nothing

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

   
    Private Sub txtBuscador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscador.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.Cursor = Cursors.AppStarting
            btnBuscar_Click(sender, e)
        End If
    End Sub

End Class