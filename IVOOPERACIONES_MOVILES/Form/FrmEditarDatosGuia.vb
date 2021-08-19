Public Class FrmEditarDatosDocumentos

    Public iWinDireccion As New AutoCompleteStringCollection
    Public coll_Direccion As New Collection
    Public coll_Tipo_Entrega As New Collection
    Dim dvListar_tipo_entrega As New DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmEditarDatosDocumentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmEditarDatosDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load    
        Dim dto_general As New ClsLbTepsa.dtoGENERAL
        Try
            dto_general.fn_L_TIPO_ENTREGA(dvListar_tipo_entrega, cmbTipoEntrega)
            'ModuUtil.LlenarComboIDs(ObjEditarDatosDocumentos.fnTipo_Entrega(), cmbTipoEntrega, coll_Tipo_Entrega, 0)

            'cmbTipoEntrega
            'If ObjEditarDatosDocumentos.fnCONTROL_DATOS_MOVIL() = True Then
            '    txtDNI.Text = ObjEditarDatosDocumentos.NROSUNAT
            '    txtNdoDoc.Text = ObjEditarDatosDocumentos.NroDoc
            '    txtrazonSocial.Text = ObjEditarDatosDocumentos.Razon_Social
            '    txtFecha.Text = ObjEditarDatosDocumentos.Fecha_Doc
            '    txtCantidad.Text = ObjEditarDatosDocumentos.Cantidad
            '    NroSobres.Text = ObjEditarDatosDocumentos.Sobres
            '    txtDireccion.Text = ObjEditarDatosDocumentos.Direccion
            '    fnCargar_iWin(txtDireccion, ObjEditarDatosDocumentos.cur_Direcciones, coll_Direccion, iWinDireccion, ObjEditarDatosDocumentos.Iddireccion_Consignado)
            '    'cmbTipoEntrega

            'Else
            '    MsgBox("No existen Resultados...Revizar Datos", MsgBoxStyle.Information, "Seguridad Sistema")
            'End If
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        fnGrabar()
    End Sub
    Private Sub fnGrabar()
        Try
            If txtDireccion.Text <> "" Then
                ObjEditarDatosDocumentos.v_idSolicitud = "0"
                Dim indexof As Integer = iWinDireccion.IndexOf(txtDireccion.Text.ToString())
                '
                'Mod.30/09/2009 -->Omendoza - Pasando al datahelper -  
                '
                'ObjEditarDatosDocumentos.idTipo_Entrega = Int(coll_Tipo_Entrega.Item(cmbTipoEntrega.SelectedIndex.ToString()))
                ObjEditarDatosDocumentos.idTipo_Entrega = Int(dvListar_tipo_entrega.Item(cmbTipoEntrega.SelectedIndex.ToString()))

                If indexof >= 0 Then
                    ObjEditarDatosDocumentos.Iddireccion_Consignado = coll_Direccion.Item(indexof.ToString)
                    ObjEditarDatosDocumentos.Direccion = txtDireccion.Text
                    ObjEditarDatosDocumentos.fnINSUD_DATOS_DOC()
                Else
                    ObjEditarDatosDocumentos.Iddireccion_Consignado = 0
                    ObjEditarDatosDocumentos.Direccion = txtDireccion.Text
                    ObjEditarDatosDocumentos.fnINSUD_DATOS_DOC()
                    ' MsgBox("No Puede realizar Esta Operacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MsgBox("Debe Digitar una direccion...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                If txtNdoDoc.Focused = True Then
                    'fnBuscarDatos(3)
                    fnBuscar()
                    SendKeys.Send("{Tab}")
                Else
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Close()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                Try
                    If Me.btnGrabar.Enabled Then
                        fnGrabar()
                    End If
                Catch ex As Exception
                    MsgBox("Revice sus Datos...", MsgBoxStyle.Information, "Seguridad Sistema")
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                If MsgBox("Esta Seguro que quiere salir de ventas al contado ", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Close()
                End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    Public Sub fnBuscar()
        Try
            If Me.txtNdoDoc.Text = "" Then

                Return
            End If

            Dim strNroDoc As String() = Split(txtNdoDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                    ObjEditarDatosDocumentos.Serie = strNroDoc(0)
                    ObjEditarDatosDocumentos.NroDoc = strNroDoc(1)
                Else
                    ObjEditarDatosDocumentos.Serie = "0"
                    ObjEditarDatosDocumentos.NroDoc = strNroDoc(0)
                End If

            Else
                If strNroDoc.Length = 1 Then
                    ObjEditarDatosDocumentos.Serie = "0"
                    ObjEditarDatosDocumentos.NroDoc = "0"
                    If txtNdoDoc.Text <> "" Then
                        ObjEditarDatosDocumentos.NroDoc = strNroDoc(0)
                    End If
                Else
                    ObjEditarDatosDocumentos.Serie = "0"
                    ObjEditarDatosDocumentos.NroDoc = "0"
                End If

            End If

            'ObjEditarDatosDocumentos.Serie = ""
            'Public NroDoc As String
            'Mod.30/09/2009 -->Omendoza - Pasando al datahelper  
            If ObjEditarDatosDocumentos.fnSP_CONTROL_DIRECION() = True Then
                txtDNI.Text = ObjEditarDatosDocumentos.NROSUNAT
                txtNdoDoc.Text = ObjEditarDatosDocumentos.NroDoc
                txtrazonSocial.Text = ObjEditarDatosDocumentos.Razon_Social
                txtFecha.Text = ObjEditarDatosDocumentos.Fecha_Doc
                txtCantidad.Text = ObjEditarDatosDocumentos.Cantidad
                NroSobres.Text = ObjEditarDatosDocumentos.Sobres
                txtDireccion.Text = ObjEditarDatosDocumentos.Direccion
                '              
                'fnCargar_iWin(txtDireccion, ObjEditarDatosDocumentos.cur_Direcciones, coll_Direccion, iWinDireccion, ObjEditarDatosDocumentos.Iddireccion_Consignado)
                fnCargar_iWin_dt(txtDireccion, ObjEditarDatosDocumentos.dt_cur_Direcciones, coll_Direccion, iWinDireccion, ObjEditarDatosDocumentos.Iddireccion_Consignado)
                'Mod.30/09/2009 -->Omendoza - Pasando al datahelper -  
                'ModuUtil.LlenarComboIDs(ObjEditarDatosDocumentos.fnTipo_Entrega(), cmbTipoEntrega, coll_Tipo_Entrega, ObjEditarDatosDocumentos.idTipo_Entrega)
                ModuUtil.LlenarComboIDs_dt(ObjEditarDatosDocumentos.dt_tipo_entrega, cmbTipoEntrega, coll_Tipo_Entrega, ObjEditarDatosDocumentos.idTipo_Entrega)
                '
                cmbTipoEntrega.Focus()
            Else
                MsgBox("No existen datos para esta Busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoEntrega.SelectedIndexChanged
        Try
            'ObjEditarDatosDocumentos.idTipo_Entrega = Int(coll_Tipo_Entrega.Item(cmbTipoEntrega.SelectedIndex.ToString()))
            'txtDireccion.Text = cmbTipoEntrega.Text
            'If ObjEditarDatosDocumentos.idTipo_Entrega = 2 Then
            '    txtDireccion.Text = ""
            'Else
            '    txtDireccion.Text = cmbTipoEntrega.Text
            'End If

        Catch ex As Exception

        End Try
    End Sub
End Class