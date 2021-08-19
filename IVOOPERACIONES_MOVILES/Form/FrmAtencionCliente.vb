Public Class FrmAtencionCliente
    Public iWinPerosa As New AutoCompleteStringCollection
    Public iWinPerosaRUC As New AutoCompleteStringCollection
    Public iWinDistrito As New AutoCompleteStringCollection

    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection
    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public coll_Lista_Personas As New Collection
    Public coll_Lista_Distritos As New Collection

    Dim ObjSolicitudRecojoEntrega As New dtoSolicitudRecojoEntrega
    Dim Control As Integer = 0
    Dim bControl_Busqueda As Boolean = False
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        fnGrabar()
    End Sub
    Private Sub fnGrabar()
        Try
            ObjSolicitudRecojoEntrega.v_Control = 1
            ObjSolicitudRecojoEntrega.v_Idsolicitud_Recojo_Carga = 0
            If txtDistritos.Text = "" Or txtDistritos.Text = " " Then
                MsgBox("Debe Elegir un distrito para esta direccion...", MsgBoxStyle.Information, "Seguridad Sistema")

                txtDistritos.Focus()
                txtDistritos.SelectAll()
                Return
            End If

            Dim indexof As String


            If iWinPerosa.Count > 0 Then
                indexof = iWinPerosa.IndexOf(TxtRasonSocial.Text.ToString())
                ObjSolicitudRecojoEntrega.v_idPersona = 0
                If indexof >= 0 Then
                    ObjSolicitudRecojoEntrega.v_idPersona = Int(coll_Lista_Personas.Item(indexof.ToString))
                Else
                    ObjSolicitudRecojoEntrega.v_idPersona = 0
                End If
            End If
            'ObjSolicitudRecojoEntrega.v_idPersona = "1605"
            ObjSolicitudRecojoEntrega.v_idAgencias = dtoUSUARIOS.m_iIdAgencia
            'fnCargar_iWin2(txtOperador, ObjSolicitudRecojoEntrega.cur_Nombres_Remitente, ObjSolicitudRecojoEntrega.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
            ObjSolicitudRecojoEntrega.v_Operador_Cliente = IIf(txtOperador.Text <> "", txtOperador.Text, "NULL")
            If iWinContacto_Remitente.Count > 0 Then
                indexof = iWinContacto_Remitente.IndexOf(txtOperador.Text.ToString())
                ObjSolicitudRecojoEntrega.v_idOperador_Cliente = 0
                If indexof >= 0 Then
                    ObjSolicitudRecojoEntrega.v_idOperador_Cliente = Int(ObjSolicitudRecojoEntrega.coll_Nombres_Remitente.Item(indexof.ToString))
                Else
                    ObjSolicitudRecojoEntrega.v_idOperador_Cliente = 0
                End If
            End If
            'ObjSolicitudRecojoEntrega.v_idOperador_Cliente = 5222
            ObjSolicitudRecojoEntrega.v_fecha_OPeracion = dtFechaOperacion.Text.ToString()
            ObjSolicitudRecojoEntrega.v_idEstado_Carga = 11 ' Por Recoger
            ObjSolicitudRecojoEntrega.v_Direccion_Recojo = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "NULL")
            If iWinDireccion_Remitente.Count > 0 Then
                indexof = iWinDireccion_Remitente.IndexOf(txtDireccionRemitente.Text.ToString())
                ObjSolicitudRecojoEntrega.v_idDireccion_Recojo = 0
                If indexof >= 0 Then
                    ObjSolicitudRecojoEntrega.v_idDireccion_Recojo = Int(ObjSolicitudRecojoEntrega.coll_Direccion_Remitente.Item(indexof.ToString))
                Else
                    ObjSolicitudRecojoEntrega.v_idDireccion_Recojo = 0
                End If
            End If

            'ObjSolicitudRecojoEntrega.v_idDireccion_Recojo = 0

            ObjSolicitudRecojoEntrega.v_Referencia_Lugar = IIf(txtLugarReferencia.Text <> "", txtLugarReferencia.Text, "NULL")
            ObjSolicitudRecojoEntrega.v_idUnidad_Agencia = dtoUSUARIOS.m_idciudad

            If iWinDistrito.Count > 0 Then
                indexof = iWinDistrito.IndexOf(txtDistritos.Text.ToString())
                ObjSolicitudRecojoEntrega.v_idDistrito = 0
                If indexof >= 0 Then
                    ObjSolicitudRecojoEntrega.v_idDistrito = Int(coll_Lista_Distritos.Item(indexof.ToString))
                Else
                    ObjSolicitudRecojoEntrega.v_idDistrito = 0
                End If
            Else
                MsgBox("No Existe un Distrito asociado..., revice sus datos..", MsgBoxStyle.Information, "Seguridad Sistema")
            End If


            ObjSolicitudRecojoEntrega.v_Hora_Incio = IIf(txtHoraIni.Text <> "", txtHoraIni.Text, "00:00")
            ObjSolicitudRecojoEntrega.v_Hora_Final = IIf(txtHoraFin.Text <> "", txtHoraFin.Text, "00:00")

            ObjSolicitudRecojoEntrega.v_Atemdido = "N"
            ObjSolicitudRecojoEntrega.v_Tipo_Operacion = "R" ' ---- R := Recojo E := Entrega

            ObjSolicitudRecojoEntrega.v_IdPersonal_Recojo = Int(ObjEntregaCarga.col_Responsable.Item(cmbResponsableMovil.SelectedIndex.ToString()))
            ObjSolicitudRecojoEntrega.v_Idsolicitud_Recojo_Carga = Int(ObjEntregaCarga.col_Responsable.Item(cmbResponsableMovil.SelectedIndex.ToString()))

            ObjSolicitudRecojoEntrega.v_Peso_Recojo = IIf(txtPeso.Text <> "", txtPeso.Text, 0)
            ObjSolicitudRecojoEntrega.v_Cantidad_Recojo = IIf(txtCantidad.Text <> "", txtCantidad.Text, 0)
            ObjSolicitudRecojoEntrega.v_Observacion = IIf(txtObs.Text <> "", txtObs.Text, "NULL")
            ObjSolicitudRecojoEntrega.v_Destino = IIf(txtDestino.Text <> "", txtDestino.Text, "NULL")

            If ObjSolicitudRecojoEntrega.fnSP_SOLICITUD_DATOS() = False Then
                MsgBox("Revise sus datos no puede realizar esta operación", MsgBoxStyle.Information, "Seguridad Sistema")
            Else
                Close()
                'fnLimpiarCampos()
            End If
        Catch ex As Exception
            MsgBox("Revise sus datos,...No se ha podido realizar está Solicitud", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Function fnLimpiarCampos() As Boolean
        Try

            TxtRasonSocial.Text = ""
            TxtRuc.Text = ""
            txtOperador.Text = ""
            txtDNIRemitente.Text = ""
            txtTelefono.Text = ""
            txtDireccionRemitente.Text = ""
            dtFechaOperacion.Text = ""
            txtDireccionRemitente.Text = ""
            txtLugarReferencia.Text = ""
            txtDistritos.Text = ""
            txtHoraIni.Text = ""
            txtHoraFin.Text = ""
            txtCantidad.Text = ""
            txtPeso.Text = ""
            txtDestino.Text = ""
            txtObs.Text = ""
            TxtRasonSocial.Focus()
            'cmbResponsableMovil
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Private Sub FrmAtencionCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmAtencionCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtFechaOperacion.Text = dtoUSUARIOS.m_sFecha

            txtHoraIni.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()
            txtHoraFin.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()

            If ObjFiltrosEntregaRecojos.fnSP_CONTROL_RECOJOS() = False Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                'fnCargar_iWin2(Me.TxtRasonSocial, ObjFiltrosEntregaRecojos.CUR_DATOS, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)
                fnCargar_iWin2(Me.TxtRasonSocial, ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(0), coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)
            End If

            ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(1), cmbEstados, ObjEntregaCarga.col_Estados, 999)
            ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(2), cmbResponsableMovil, ObjEntregaCarga.col_Responsable, ObjFiltrosEntregaRecojos.fnSP_LISTA_JEFE_AREAMOVIL())

            ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(3), cmbAtendido, ObjFiltrosEntregaRecojos.col_sino, 9)
            ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(4), cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 999)
            '
            fnCargar_iWin_dt(txtDistritos, ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(5), coll_Lista_Distritos, iWinDistrito, 0)
            '
            'If objGuiaEnvio.fnLISTA_PERSONAS() = True Then
            '    fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)
            'End If

            'ModuUtil.LlenarComboIDs(ObjEntregaCarga.fnEstadoRegistros(), cmbEstados, ObjEntregaCarga.col_Estados, 999)
            'ModuUtil.LlenarComboIDs(ObjEntregaCarga.fnLISTAR_RESPONSABLES_MOVIL(), cmbResponsableMovil, ObjEntregaCarga.col_Responsable, 999)

            'If ObjFiltrosEntregaRecojos.fnLISTA_SINO_TIPO() = False Then
            '    ModuUtil.LlenarComboIDs(ObjFiltrosEntregaRecojos.CUR_DATOS, cmbAtendido, ObjFiltrosEntregaRecojos.col_sino, 9)
            '    ModuUtil.LlenarComboIDs(ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 999)
            'End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Load_Grid()
        Try
            With DataGridViewDocumentos
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With

        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            flat = MyBase.ProcessCmdKey(msg, KeyData)
            If msg.WParam.ToInt32 = Keys.Enter Then
                If TxtRasonSocial.Focused = True Then
                    'objLOG.fnLog("[ENTER] :" & TxtRasonSocial.Text.ToString)
                    Control = 2
                    Dim indexof As Integer = 0
                    If iWinPerosa.Count > 0 Then
                        'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                        indexof = IIf(iWinPerosa.IndexOf(TxtRasonSocial.Text) >= 0, iWinPerosa.IndexOf(TxtRasonSocial.Text), -1)
                        objGuiaEnvio.iIDPERSONA = -1
                        If indexof >= 0 Then
                            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                            objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                            If indexof <= iWinPerosaRUC.Count Then
                                Me.TxtRuc.Text = iWinPerosaRUC.Item(indexof)
                                txtOperador.Text = TxtRasonSocial.Text
                                bControl_Busqueda = True
                                If ObjSolicitudRecojoEntrega.fnBUSCAR_DATOS_CLIENTE(1, objGuiaEnvio.iIDPERSONA.ToString, dtoUSUARIOS.m_idciudad) = True Then
                                    'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
                                    'If ObjSolicitudRecojoEntrega.cur_Nombres_Remitente.BOF = False And ObjSolicitudRecojoEntrega.cur_Nombres_Remitente.EOF = False Then
                                    If ObjSolicitudRecojoEntrega.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                                        'objGuiaEnvio.iIDCONTACTO_PERSONA = Int(ObjSolicitudRecojoEntrega.cur_Nombres_Remitente.Fields.Item(0).Value.ToString)
                                        'txtOperador.Text = ObjSolicitudRecojoEntrega.cur_Nombres_Remitente.Fields.Item(1).Value.ToString
                                        'txtDNIRemitente.Text = ObjSolicitudRecojoEntrega.cur_Nombres_Remitente.Fields.Item(2).Value.ToString
                                        'fnCargar_iWin2(txtOperador, ObjSolicitudRecojoEntrega.cur_Nombres_Remitente, ObjSolicitudRecojoEntrega.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
                                        objGuiaEnvio.iIDCONTACTO_PERSONA = Int(ObjSolicitudRecojoEntrega.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                                        txtOperador.Text = ObjSolicitudRecojoEntrega.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                                        txtDNIRemitente.Text = ObjSolicitudRecojoEntrega.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                                        fnCargar_iWin2_dt2(txtOperador, ObjSolicitudRecojoEntrega.dt_cur_Nombres_Remitente, ObjSolicitudRecojoEntrega.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
                                        txtOperador.Focus()
                                        txtOperador.SelectAll()
                                    Else
                                        objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                                        txtOperador.Text = ""
                                        ' Me.txtDNIRemitente.Text = ""
                                    End If
                                    '//CONTACTO DIRECCIONES
                                    'If ObjSolicitudRecojoEntrega.cur_Direccion_Remitente.BOF = False And ObjSolicitudRecojoEntrega.cur_Direccion_Remitente.EOF = False Then
                                    If ObjSolicitudRecojoEntrega.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                                        objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(ObjSolicitudRecojoEntrega.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                                        txtDireccionRemitente.Text = ObjSolicitudRecojoEntrega.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                                        fnCargar_iWin_dt(txtDireccionRemitente, ObjSolicitudRecojoEntrega.dt_cur_Direccion_Remitente, ObjSolicitudRecojoEntrega.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                                    Else
                                        txtDireccionRemitente.Text = ""
                                        objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                                    End If
                                Else
                                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                                    txtOperador.Text = ""
                                    txtDireccionRemitente.Text = ""
                                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                                End If


                            End If
                        Else
                            MsgBox("El Nombre del Cliente No Tiene Linea de Credito, Revice sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If

                ElseIf TxtRuc.Focused = True Then
                    Control = 2
                    Dim indexof As Integer = 0
                    If iWinPerosa.Count > 0 Then
                        indexof = iWinPerosaRUC.IndexOf(TxtRuc.Text)
                        objGuiaEnvio.iIDPERSONA = -1
                        If indexof >= 0 Then
                            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                            objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                            If indexof <= iWinPerosa.Count Then
                                Me.TxtRasonSocial.Text = iWinPerosa.Item(indexof)
                                objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                                objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                                objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                                bControl_Busqueda = True
                            End If
                        Else
                            MsgBox("El Nombre del Cliente No Tiene Linea de Credito, Revice sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    End If

                Else
                    SendKeys.Send("{Tab}")
                    'flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                Close()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                'cambio tecla funcion
                If btnGrabar.Enabled Then
                    fnGrabar()
                End If

                ElseIf msg.WParam.ToInt32 = Keys.F2 Then
                    TxtRasonSocial.Focus()
                    TxtRasonSocial.SelectAll()
                ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                    txtDireccionRemitente.Focus()
                    txtDireccionRemitente.SelectAll()
                ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                    txtDistritos.Focus()
                    txtDistritos.SelectAll()
                ElseIf msg.WParam.ToInt32 = Keys.F10 Then
                    txtHoraIni.Focus()
                    txtHoraIni.SelectAll()
                ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                    fnLimpiar()
                    TxtRasonSocial.Focus()
                    TxtRasonSocial.SelectAll()
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If


        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
            objGuiaEnvio.iCONTROL = 1
        End Try
        Return flat
    End Function

    
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            fnLimpiar()
            TxtRasonSocial.Focus()
            TxtRasonSocial.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fnLimpiar()
        Try
            TxtRasonSocial.Text = ""
            TxtRuc.Text = ""
            txtOperador.Text = ""
            txtDNIRemitente.Text = ""
            txtTelefono.Text = ""
            txtDireccionRemitente.Text = ""
            txtLugarReferencia.Text = ""
            txtDistritos.Text = ""
            txtHoraIni.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()
            txtHoraFin.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()
        Catch ex As Exception

        End Try
    End Sub
End Class