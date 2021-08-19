Public Class FrmRecepcionDocumentosGUIAS
    Dim ObjRecepcionCargo As New dtoRecepcionCargo()
    Dim bIngreso As Boolean = False
    Dim intContador As Integer = 0, intContador1 As Integer, intContador2 As Integer
    Public hnd As Long
    Private Sub fnClearObjetos()
        Try
            Me.txtNroGuia.SelectAll()
            txtCliente.Text = ""
            txtNroRuc.Text = ""
            txtOrigen.Text = ""
            TxtDestino.Text = ""
            txtFecha_Cargo.Text = ""
            txtEstado.Text = ""
            txtEstadoEnvio.Text = ""
            txtCantBultos.Text = ""
            txtTotalPeso.Text = ""
            txtTotalVolumen.Text = ""
            txtCantidadSobres.Text = ""
            txtFecha_Registro.Text = ""
            txtFecha_Despacho.Text = ""
            txtFecha_Llegada.Text = ""
            txtFecha_Entrega.Text = ""
            txtUsuarioRegistro.Text = ""
            txtUsuarioDespacho.Text = ""
            txtUsuarioLlegada.Text = ""
            txtUsuarioEntraga.Text = ""
            txttipo_comprobante.Text = ""
            Me.rtb.Text = ""
            Me.RTB2.Text = ""
            txtUsuarioDoc.Text = ""
            Me.txtCargo.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RecepcionGuias()
        Cursor = Cursors.WaitCursor
        Try
            'If fnValidar_Rol("17") = True Or fnValidar_Rol("18") = True Or fnValidar_Rol("19") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                If InStr(txtNroGuia.Text.Trim, "-") = 0 Then
                    txtNroGuia.Text = RellenoRight(13, txtNroGuia.Text)
                Else
                    txtNroGuia.Text = txtNroGuia.Text.Trim
                End If

                ObjRecepcionCargo.v_NRO_GUIA_ENVIO = LTrim(txtNroGuia.Text)
                ObjRecepcionCargo.v_CARGO_DOC = 1
                ObjRecepcionCargo.v_FECHA_DOC = Me.txtFechaRecepcion.Text
                If Len(rtb.Text) = 0 Then
                    ObjRecepcionCargo.obs_recep_docu = "NULL"
                Else
                    ObjRecepcionCargo.obs_recep_docu = Me.rtb.Text
                End If
                If Me.RBEnConfor.Checked = True Then
                    ObjRecepcionCargo.V_idtipo_recepcion_docu = "ENCO"
                ElseIf Me.RBEnObser.Checked = True Then
                    ObjRecepcionCargo.V_idtipo_recepcion_docu = "ENOB"
                Else
                    ObjRecepcionCargo.V_idtipo_recepcion_docu = "PEND"
                End If


                fnClearObjetos()

                'Dim cmd As New OracleClient.OracleCommand
                'cmd.CommandText = "PKG_IVORECEPCION_CARGA.sp_si_mayor_que_uno"
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.Connection = cnn
                'cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_guia", OracleClient.OracleType.VarChar, 13)).Value = ObjRecepcionCargo.v_NRO_GUIA_ENVIO
                'cmd.Parameters.Add(New OracleClient.OracleParameter("v_cuantos", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

                'cmd.ExecuteNonQuery()
                'If Not cmd.Parameters("v_cuantos").Value Is DBNull.Value Then

                '    If cmd.Parameters("v_cuantos").Value > 1 Then
                '        Dim B As New FrmConfirmarBolFac
                '        B.ShowDialog()
                '        ObjRecepcionCargo.v_idtipo_comprobante = factura_o_boleta

                '    End If
                'End If

                If InStr(ObjRecepcionCargo.v_NRO_GUIA_ENVIO, "-") = 0 Then
                    ObjRecepcionCargo.v_idtipo_comprobante = 3
                Else
                    ObjRecepcionCargo.v_idtipo_comprobante = 0
                End If
                ' 'Mod. 10/09/2009 - x Datahelper 
                Dim li_cuantos As Integer
                li_cuantos = ObjRecepcionCargo.fnRECEPCION_CARGO_veirifica_existe_dcto()
                If li_cuantos > 1 Then
                    Dim B As New FrmConfirmarBolFac
                    'B.ShowDialog()

                    Acceso.Asignar(B, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        B.ShowDialog()
                        ObjRecepcionCargo.v_idtipo_comprobante = factura_o_boleta
                    Else
                        MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If

                Dim blnExiste As Boolean = dtoRecepcionCargo.ExisteGuiaEnvio(ObjRecepcionCargo.v_NRO_GUIA_ENVIO, ObjRecepcionCargo.v_idtipo_comprobante, ObjRecepcionCargo.V_idtipo_recepcion_docu)
                If Not blnExiste Then
                    If Me.RBEnConfor.Checked Then
                        intContador += 1
                        Me.lblContador.Text = intContador
                    ElseIf RBPEND_DEVOL.Checked Then
                        intContador1 += 1
                        Me.lblContador1.Text = intContador1
                    ElseIf RBEnObser.Checked Then
                        intContador2 += 1
                        Me.lblContador2.Text = intContador2
                    End If
                End If

                If ObjRecepcionCargo.fnRECEPCION_CARGO_SITU_III() = True Then
                    txtCliente.Text = ObjRecepcionCargo.Razon_Social
                    txtNroRuc.Text = ObjRecepcionCargo.Nu_Docu_Suna
                    txtOrigen.Text = ObjRecepcionCargo.Origen
                    TxtDestino.Text = ObjRecepcionCargo.Destino
                    txtFecha_Cargo.Text = ObjRecepcionCargo.Fecha_Doc
                    txtEstado.Text = ObjRecepcionCargo.Estado_Registro
                    txtEstadoEnvio.Text = ObjRecepcionCargo.EstadoEnvio
                    txtCantBultos.Text = ObjRecepcionCargo.cantidad
                    txtTotalPeso.Text = ObjRecepcionCargo.Total_Peso
                    txtTotalVolumen.Text = ObjRecepcionCargo.Total_Volumen
                    txtCantidadSobres.Text = ObjRecepcionCargo.Cantidad_Sobres
                    txtFecha_Registro.Text = ObjRecepcionCargo.Fecha_Guia
                    txtFecha_Despacho.Text = ObjRecepcionCargo.Fecha_Despacho
                    txtFecha_Llegada.Text = ObjRecepcionCargo.Fecha_Llegada
                    txtFecha_Entrega.Text = ObjRecepcionCargo.Fecha_Entrega
                    txtUsuarioRegistro.Text = ObjRecepcionCargo.UsuarioRegistro
                    txtUsuarioDespacho.Text = ObjRecepcionCargo.UsuarioDespacho
                    txtUsuarioLlegada.Text = ObjRecepcionCargo.UsuarioEntrega
                    txtUsuarioEntraga.Text = ObjRecepcionCargo.UsuarioEntrega
                    txtUsuarioDoc.Text = ObjRecepcionCargo.UsuarioDoc
                    txttipo_comprobante.Text = ObjRecepcionCargo.tipo_comprobante
                    RTB2.Text = ObjRecepcionCargo.obs_recep_docu

                    'hlamas 22-07-2015
                    Me.txtCargo.Text = ObjRecepcionCargo.strCargo

                    'hlamas 12-08-2019
                    Me.txtTipoFacturacion.Text = ObjRecepcionCargo.TipoFacturacion

                End If
            Else
                Cursor = Cursors.Default
                MsgBox("No tiene permiso para realizar esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmRecepcionDocumentosGUIAS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmRecepcionDocumentosGUIAS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRecepcionDocumentosGUIAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            intContador = 0 : intContador1 = 0 : intContador2 = 0
            txtFechaRecepcion.Text = dtoUSUARIOS.m_sFecha
            txtFechaRecepcion.Enabled = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtNroGuia_Invalidated(sender As Object, e As System.Windows.Forms.InvalidateEventArgs) Handles txtNroGuia.Invalidated

    End Sub
    Private Sub txtNroGuia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                RecepcionGuias()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtNroGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroGuia.TextChanged

    End Sub

    Private Sub GroupBox4_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class