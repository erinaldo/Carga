Public Class FrmRegistroGenerico

    Dim col_Origen As New Collection
    Dim col_Destino As New Collection
    Dim col_FormaPago As New Collection
    Dim col_TipoPago As New Collection
    Dim col_TipoEntrega As New Collection
    Dim col_Tarjetas As New Collection
    Dim col_Usuarios As New Collection
    Dim Control As Integer = 1
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmRegistroGenerico_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmRegistroGenerico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRegistroGenerico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim lds_tmp As New DataSet
            'Mod.15/09/2009 -->Omendoza - Pasando al datahelper   
            'rst = ObjRegistroGenerico.fnSP_LISTA_DATOS_GENERICOS()
            'ModuUtil.LlenarComboIDs2(rst, cmbAgOrigen, col_Origen, dtoUSUARIOS.m_iIdAgencia, cmbAgDestino, col_Destino, 0)
            'ModuUtil.LlenarComboIDs(rst.NextRecordset, cmbFormaPago, col_FormaPago, 1)
            'ModuUtil.LlenarComboIDs(rst.NextRecordset, cmbTipoPago, col_TipoPago, 1)
            'ModuUtil.LlenarComboIDs(rst.NextRecordset, cmbTipo_Entrega, col_TipoEntrega, 1)
            'ModuUtil.LlenarComboIDs(rst.NextRecordset, cmbTargeta, col_Tarjetas, 1)
            '
            lds_tmp = ObjRegistroGenerico.fnSP_LISTA_DATOS_GENERICOS()
            ModuUtil.LlenarComboIDs2(lds_tmp.Tables(0), cmbAgOrigen, col_Origen, dtoUSUARIOS.m_iIdAgencia, cmbAgDestino, col_Destino, 0)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(1), cmbFormaPago, col_FormaPago, 1)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(2), cmbTipoPago, col_TipoPago, 1)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(3), cmbTipo_Entrega, col_TipoEntrega, 1)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(4), cmbTargeta, col_Tarjetas, 1)
            '
            txtFecha.Text = dtoUSUARIOS.m_sFecha

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub cmbAgOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgOrigen.SelectedIndexChanged
        Try
            ObjRegistroGenerico.v_idagencias = Int(col_Origen.Item(cmbAgOrigen.SelectedIndex.ToString))
            If ObjRegistroGenerico.v_idagencias >= 0 Then
                ModuUtil.LlenarComboIDs_dt(ObjRegistroGenerico.fnSP_LISTA_USUARIOS(), cmbUsuarios, col_Usuarios, 0)
            Else
                cmbUsuarios.Controls.Clear()
                cmbUsuarios.Items.Clear()
                col_Usuarios.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                If txtNroDocumento.Focused = True Then
                    'fnTarifario()
                    fnBuscar()
                    'If Me.dtGridViewBultos.Focused = True Then
                    '    'fnTarifario()
                    '    SendKeys.Send("{Tab}")
                    'ElseIf txtNroSerieDoc.Focused = True Then
                    '    objControlFacturasBol.iControl = 2
                    '    fnBuscarFacturas()
                    'ElseIf txtClienteDNIRUC.Focused = True Then
                    '    objControlFacturasBol.iControl = 3
                    '    fnBuscarFacturas()

                    'ElseIf txtDocCliente_Remitente.Focused = True Then
                    '    Control = 2
                    '    objGuiaEnvio.iIDPERSONA = 1
                    '    fnBuscarCliente()
                    '    'If BuscarClientesGuia_Envio() = True Then
                    '    '    SendKeys.Send("{Tab}")
                    '    'End If
                Else
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                cmbTipo_Entrega.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F2 Then
                txtDocCliente_Remitente.SelectAll()
                txtDocCliente_Remitente.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                fnNuevo()
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtDNIDestinatario.SelectAll()
                txtDNIDestinatario.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                If btnGrabar.Enabled Then
                    Grabar()
                End If
                'If fnGrabar() = True Then
                '    txtNroDocumento.Focus()
                '    fnNuevo()
                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                txtCantidad_Peso.SelectAll()
                txtCantidad_Peso.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                txtPorcernt_Descuento.SelectAll()
                txtPorcernt_Descuento.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                txtSERIE.SelectAll()
                txtSERIE.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F11 Then
                txtNroDocumento.SelectAll()
                txtNroDocumento.Focus()
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
            'ElseIf msg.WParam.ToInt32 = Keys.F1 Then
            '    cmbTipo_Entrega.Focus()
            'ElseIf msg.WParam.ToInt32 = Keys.F2 Then
            '    txtDocCliente_Remitente.Focus()
            'ElseIf msg.WParam.ToInt32 = Keys.Escape Then
            '    If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
            '        fnNUEVO()
            '    End If
            'ElseIf msg.WParam.ToInt32 = Keys.F3 Then
            '    fnNUEVO()
            '    SelectMenu(1)
            'ElseIf msg.WParam.ToInt32 = Keys.F4 Then
            '    txtDNIDestinatario.Focus()
            '    txtDNIDestinatario.SelectAll()
            'ElseIf msg.WParam.ToInt32 = Keys.F5 Then
            '    If control_venta = True Then
            '        fnNUEVO()
            '        control_venta = False
            '    End If
            '    If TipoComprobante = 1 Then
            '        If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
            '            If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
            '                MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
            '            End If
            '        Else
            '            MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
            '        End If
            '    End If
            '    If txtCliente_Remitente.Text = "" Then
            '        MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
            '        txtCliente_Remitente.Focus()
            '        Return False
            '    End If
            '    If txtCliente_Destinatario.Text = "" Then
            '        MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
            '        txtCliente_Destinatario.Focus()
            '        Return False
            '    End If
            '    If Val(txtCosto_Total.Text) <= 0 Then
            '        MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...", MsgBoxStyle.Information, "Seguridad Sistema")
            '        Return False
            '    End If

            '    If fnGrabar() = True Then
            '        ObjVentaCargaContado.fnIncrementarNroDoc(TipoComprobante)
            '    End If
            'ElseIf msg.WParam.ToInt32 = Keys.F7 Then
            '    dtGridViewBultos.Focus()
            '    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
            '    dtGridViewBultos.Rows(0).Cells(2).Selected = True

            'ElseIf msg.WParam.ToInt32 = Keys.F6 Then
            '    If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then

            '    End If

            '    If txtContactoRemitente.Focused = True Or txtDNIContacto.Focused = True Then
            '        If txtContactoRemitente.Text <> "" Then
            '            If fnMantenimienteCliente(2, txtDNIContacto, txtContactoRemitente, txtDireccionRemitente, 1, 2) = True Then

            '            End If
            '        End If


            '    End If


            '    '    txtCantidad_Peso.Focus()
            '    'txtCantidad_Peso.SelectAll()

            'ElseIf msg.WParam.ToInt32 = Keys.F8 Then
            '    txtPorcernt_Descuento.Focus()
            '    txtPorcernt_Descuento.SelectAll()
            'ElseIf msg.WParam.ToInt32 = Keys.F9 Then
            '    txtNroDocFACBOL.Focus()
            '    txtNroDocFACBOL.SelectAll()
            'ElseIf msg.WParam.ToInt32 = Keys.F10 Then
            '    txtiWinDestino.Focus()
            '    txtiWinDestino.SelectAll()
            'ElseIf msg.WParam.ToInt32 = Keys.F12 Then
            '    If MsgBox("Esta Seguro que quiere salir de ventas al contado ", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
            '        Close()
            '    End If

            'Else
            'flat = MyBase.ProcessCmdKey(msg, KeyData)
            'End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    Private Function fnBuscar() As Boolean
        Try
            Dim strNroDoc As String() = Split(txtNroDocumento.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                    ObjEntregaCarga.c_Serie = strNroDoc(0)
                    ObjEntregaCarga.c_NroDoc = strNroDoc(1)
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            Else
                If strNroDoc.Length = 1 Then
                    ObjEntregaCarga.c_Serie = "-1"
                    ObjEntregaCarga.c_NroDoc = strNroDoc(0)
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            End If
            '
            If ObjRegistroGenerico.fnSP_BUSCAR_DOCUEMENTO(ObjEntregaCarga.c_Serie, ObjEntregaCarga.c_NroDoc) Then
                Try
                    Control = 2
                    txtSERIE.Text = ObjRegistroGenerico.v_serie_factura
                    txtNroDocFACBOL.Text = ObjRegistroGenerico.v_nro_factura
                    txtFecha.Text = ObjRegistroGenerico.v_fecha_factura

                    ObjRegistroGenerico.fnSelIndex(cmbAgOrigen, col_Origen, ObjRegistroGenerico.v_idagencias)
                    ObjRegistroGenerico.fnSelIndex(cmbAgDestino, col_Destino, ObjRegistroGenerico.v_idagencias_destino)
                    ObjRegistroGenerico.fnSelIndex(cmbFormaPago, col_FormaPago, ObjRegistroGenerico.v_idforma_pago)
                    ObjRegistroGenerico.fnSelIndex(cmbTipo_Entrega, col_TipoEntrega, ObjRegistroGenerico.v_idtipo_entrega)
                    ObjRegistroGenerico.fnSelIndex(cmbTipoPago, col_TipoPago, ObjRegistroGenerico.v_idtipo_pago)
                    ObjRegistroGenerico.fnSelIndex(cmbTargeta, col_Tarjetas, ObjRegistroGenerico.v_idtarjetas)

                    txtNroTarjeta.Text = 0
                    txtCantidad_Peso.Text = ObjRegistroGenerico.v_cantidad_x_peso
                    txtCantidad_Vol.Text = ObjRegistroGenerico.v_cantidad_x_volumen
                    txtCantidad_Sobre.Text = ObjRegistroGenerico.v_cantidad_x_sobre

                    txtPeso.Text = ObjRegistroGenerico.v_total_peso
                    txtVolumen.Text = ObjRegistroGenerico.v_total_volumen

                    txtSubTotal_Peso.Text = 0
                    txtSubTotal_Vol.Text = 0
                    txtSubTotal_Sobre.Text = 0
                    txtSubTotal_Base.Text = ObjRegistroGenerico.v_monto_base
                    txtCosto_Total.Text = ObjRegistroGenerico.v_total_costo

                    txtDocCliente_Remitente.Text = ObjRegistroGenerico.v_Nu_Docu_Suna
                    txtCliente_Remitente.Text = ObjRegistroGenerico.v_Razon_Social
                    txtDireccionRemitente.Text = ObjRegistroGenerico.v_Origen_Direccion

                    txtContactoRemitente.Text = ObjRegistroGenerico.v_Origen_Contacto
                    txtDNIContacto.Text = ObjRegistroGenerico.v_DNIOrigen
                    txtPorcernt_Descuento.Text = ObjRegistroGenerico.v_porcent_descuento
                    txtMemo.Text = ObjRegistroGenerico.v_memo
                    txtDNIDestinatario.Text = ObjRegistroGenerico.v_DNIDestino
                    txtCliente_Destinatario.Text = ObjRegistroGenerico.v_Destino_Contacto
                    txtDireccionDestinatario.Text = ObjRegistroGenerico.v_Destino_Direccion
                    txtNroTarjeta.Text = ObjRegistroGenerico.v_nrotarjeta
                    lbFactBoleta.Text = ObjRegistroGenerico.v_Tipo_Comprobante
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function
    Private Function fnNuevo() As Boolean
        Try
            Control = 1
            txtSERIE.Text = ""
            txtNroDocFACBOL.Text = ""
            txtFecha.Text = dtoUSUARIOS.m_sFecha
            ObjRegistroGenerico.fnSelIndex(cmbAgOrigen, col_Origen, dtoUSUARIOS.m_iIdAgencia)
            ObjRegistroGenerico.fnSelIndex(cmbAgDestino, col_Destino, 0)
            ObjRegistroGenerico.fnSelIndex(cmbFormaPago, col_FormaPago, 1)
            ObjRegistroGenerico.fnSelIndex(cmbTipo_Entrega, col_TipoEntrega, 1)
            ObjRegistroGenerico.fnSelIndex(cmbTipoPago, col_TipoPago, 1)
            ObjRegistroGenerico.fnSelIndex(cmbTargeta, col_Tarjetas, 0)
            txtNroTarjeta.Text = 0
            txtCantidad_Peso.Text = 0
            txtCantidad_Vol.Text = 0
            txtCantidad_Sobre.Text = 0

            txtPeso.Text = 0
            txtVolumen.Text = 0

            txtSubTotal_Peso.Text = 0
            txtSubTotal_Vol.Text = 0
            txtSubTotal_Sobre.Text = 0
            txtSubTotal_Base.Text = 0.0
            txtCosto_Total.Text = 0.0

            txtDocCliente_Remitente.Text = ""
            txtCliente_Remitente.Text = ""
            txtDireccionRemitente.Text = ""

            txtContactoRemitente.Text = ""
            txtDNIContacto.Text = ""
            txtPorcernt_Descuento.Text = ""
            txtMemo.Text = ""
            txtDNIDestinatario.Text = ""
            txtCliente_Destinatario.Text = ""
            txtDireccionDestinatario.Text = ""
            txtNroTarjeta.Text = ""
            lbFactBoleta.Text = "BOLETA DE VENTA"
            ObjRegistroGenerico.fnClear()

            txtNroDocumento.SelectAll()
            txtNroDocumento.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Private Sub btnDesbloquear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesbloquear.Click
        Try
            If MsgBox("Esta Seguro de Realizar Esta Operacion?...", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                If ObjRegistroGenerico.fnSP_DESBLOQUEAR_REGISTRO() = False Then
                    MsgBox("No puede realizar está operación....", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Function fnGrabar() As Boolean
        Try
            If Int(txtSERIE.Text) > 0 And Int(txtNroDocFACBOL.Text) > 0 Then

                ObjRegistroGenerico.v_iControl = Control
                ObjRegistroGenerico.v_idfactura = 1
                ObjRegistroGenerico.v_idagencias = Int(col_Origen.Item(cmbAgOrigen.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_idagencias_destino = Int(col_Destino.Item(cmbAgDestino.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_idforma_pago = Int(col_FormaPago.Item(cmbFormaPago.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_idtipo_pago = Int(col_TipoPago.Item(cmbTipoPago.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_idtipo_entrega = Int(col_TipoEntrega.Item(cmbTargeta.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_idtarjetas = Int(col_Tarjetas.Item(cmbTargeta.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_serie_factura = txtSERIE.Text
                ObjRegistroGenerico.v_nro_factura = txtNroDocFACBOL.Text
                ObjRegistroGenerico.v_fecha_factura = txtFecha.Text
                ObjRegistroGenerico.v_idusuario_personal = Int(col_Usuarios.Item(cmbUsuarios.SelectedIndex.ToString()))
                ObjRegistroGenerico.v_monto_base = IIf(txtSubTotal_Base.Text <> "", txtSubTotal_Base.Text, 0)
                ObjRegistroGenerico.v_total_costo = IIf(txtCosto_Total.Text <> "", txtCosto_Total.Text, 0)
                ObjRegistroGenerico.v_total_peso = IIf(txtPeso.Text <> "", txtPeso.Text, 0)
                ObjRegistroGenerico.v_total_volumen = IIf(txtVolumen.Text <> "", txtVolumen.Text, 0)
                ObjRegistroGenerico.v_cantidad_x_peso = IIf(txtCantidad_Peso.Text <> "", txtCantidad_Peso.Text, 0)
                ObjRegistroGenerico.v_cantidad_x_volumen = IIf(txtCantidad_Vol.Text <> "", txtCantidad_Vol.Text, 0)
                ObjRegistroGenerico.v_cantidad_x_sobre = IIf(txtCantidad_Sobre.Text <> "", txtCantidad_Sobre.Text, 0)

                ObjRegistroGenerico.v_idremitente = IIf(ObjRegistroGenerico.v_idremitente <> 0, ObjRegistroGenerico.v_idremitente, 507)
                ObjRegistroGenerico.v_iddireecion_origen = IIf(ObjRegistroGenerico.v_iddireecion_origen <> 0, ObjRegistroGenerico.v_iddireecion_origen, 6439)
                ObjRegistroGenerico.v_iddireecion_destino = IIf(ObjRegistroGenerico.v_iddireecion_destino <> 0, ObjRegistroGenerico.v_iddireecion_destino, 6439)
                ObjRegistroGenerico.v_idcontacto_destino = IIf(ObjRegistroGenerico.v_idcontacto_destino <> 0, ObjRegistroGenerico.v_idcontacto_destino, 507)

                ObjRegistroGenerico.v_Origen_Direccion = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "NULL")
                ObjRegistroGenerico.v_Destino_Direccion = IIf(txtDireccionDestinatario.Text <> "", txtDireccionDestinatario.Text, "NULL")

                ObjRegistroGenerico.v_Origen_Contacto = IIf(txtContactoRemitente.Text <> "", txtContactoRemitente.Text, "NULL")
                ObjRegistroGenerico.v_DNIOrigen = IIf(txtDNIContacto.Text <> "", txtDNIContacto.Text, "NULL")
                ObjRegistroGenerico.v_Destino_Contacto = IIf(txtCliente_Destinatario.Text <> "", txtCliente_Destinatario.Text, "NULL")
                ObjRegistroGenerico.v_DNIDestino = IIf(txtDNIDestinatario.Text <> "", txtDNIDestinatario.Text, "NULL")

                ObjRegistroGenerico.v_Razon_Social = IIf(txtCliente_Remitente.Text <> "", txtCliente_Remitente.Text, "NULL")
                ObjRegistroGenerico.v_Nu_Docu_Suna = IIf(txtDocCliente_Remitente.Text <> "", txtDocCliente_Remitente.Text, "NULL")

                ObjRegistroGenerico.v_porcent_descuento = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)
                ObjRegistroGenerico.v_memo = IIf(txtMemo.Text <> "", txtMemo.Text, "NULL")
                ObjRegistroGenerico.v_nrotarjeta = IIf(txtNroTarjeta.Text <> "", txtNroTarjeta.Text, "NULL")
                ObjRegistroGenerico.v_Idtipo_Comprobante = 1
            Else
                MsgBox("Debe Colocar un Nº de documento válido....", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

            If ObjRegistroGenerico.fnSP_INSUP_REGISTRO_GENERICO() = False Then
                MsgBox("Revice Sus datos ....", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    Sub Grabar()
        Try
            If fnGrabar() = True Then
                txtNroDocumento.Focus()
                fnNuevo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class