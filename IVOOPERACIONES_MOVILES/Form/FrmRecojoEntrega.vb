
Public Class FrmRecojoEntrega

    'Dim rst_Datos As New ADODB.Recordset

    Dim ObjFiltrosEntregaRecojos As New dtoFiltrosEntregaRecojos
    Dim bformatImage As Boolean = False
    Dim IDGRIESTADO_REG As Integer = 2

    'Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim ObjFrm As New FrmListaSolicitudesEntregas
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub btnSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolicitud.Click
        Try
            Dim ObjFormAtencionCliente As New FrmAtencionCliente
            'ObjFormAtencionCliente.ShowDialog()
            Acceso.Asignar(ObjFormAtencionCliente, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjFormAtencionCliente.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjFormAtencionCliente = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmRecojoEntrega_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRecojoEntrega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '--------------------------------------------------------------------------------------------------------------------------
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha
            '--------------------------------------------------------------------------------------------------------------------------
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            Dim lds_tmp As New DataSet
            lds_tmp = ObjEntrega_Recojo.fnSP_CONTROL_OPERACIONES()
'
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos.NextRecordset, cmbEstados, ObjFiltrosEntregaRecojos.coll_Lista_Estados, 999)
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos.NextRecordset, cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 9999)
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos.NextRecordset, cmbAtendido, ObjFiltrosEntregaRecojos.coll_Atendido, 0)
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos.NextRecordset, cmdProcedencia, ObjFiltrosEntregaRecojos.coll_Procedencia, 999)
            '
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(0), cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(1), cmbEstados, ObjFiltrosEntregaRecojos.coll_Lista_Estados, 999)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(2), cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 9999)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(3), cmbAtendido, ObjFiltrosEntregaRecojos.coll_Atendido, 0)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(4), cmdProcedencia, ObjFiltrosEntregaRecojos.coll_Procedencia, 999)
            '
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(objGuiaEnvio.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(idAgencia) = True Then
                    '01/09/2009 - Mod. x Datahelper x Datatable
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
            Load_Grid()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(objGuiaEnvio.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(idAgencia) = True Then
                    '01/09/2009 - Mod. x Datahelper x Datatable 
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Private Sub cmbRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
    '    Try
    '        Dim idRuta As Integer
    '        idRuta = Int(cmbTipoOperacion.SelectedIndex)
    '        If idRuta >= 0 Then
    '            idRuta = IIf(cmbTipoOperacion.SelectedIndex.ToString() <> "", Int(ObjEntrega_Recojo.coll_Lista_rutas(cmbTipoOperacion.SelectedIndex.ToString())), 0)
    '            If ObjEntrega_Recojo.fnSP_DISTRITOS_RUTAS(idRuta) = True Then
    '                ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos, cmbAtendido, ObjEntrega_Recojo.coll_Lista_Distritos, 0)
    '            Else
    '                NingunoComboIDs(cmbAtendido, ObjEntrega_Recojo.coll_Lista_Distritos)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Private Sub Load_Grid()
        Try
            With dtGridViewControl_FACBOL
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
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
            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "CL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)


            Dim colSelecion As New DataGridViewCheckBoxColumn
            With colSelecion
                '.DataPropertyName = "Selecion"
                '.HeaderText = "Sel"
                '.DisplayIndex = 1
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.ReadOnly = False

                .DisplayIndex = 1
                .DataPropertyName = "Selecion"
                .HeaderText = "Sel"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colSelecion)

            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 2
                .DataPropertyName = "IDCOMPROBANTE"
                .HeaderText = "IDCOMPROBANTE"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colID)

            Dim colIDTipo_Comprobante As New DataGridViewTextBoxColumn
            With colIDTipo_Comprobante
                .DisplayIndex = 3
                .DataPropertyName = "IDTipo_Comprobante"
                .HeaderText = "IDTipo_Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colIDTipo_Comprobante)
            Dim colTipo_Operacion As New DataGridViewTextBoxColumn
            With colTipo_Operacion
                .DisplayIndex = 4
                .DataPropertyName = "Tipo_Operacion"
                .HeaderText = "T.OPERACION"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colTipo_Operacion)

            Dim colNro_Doc As New DataGridViewTextBoxColumn
            With colNro_Doc
                .DisplayIndex = 5
                .DataPropertyName = "Nro_Doc"
                .HeaderText = "Nro_Doc"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colNro_Doc)

            Dim colFecha As New DataGridViewTextBoxColumn
            With colFecha
                .DisplayIndex = 6
                .DataPropertyName = "Fecha"
                .HeaderText = "FECHA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colFecha)


            Dim colCantidad As New DataGridViewTextBoxColumn
            With colCantidad
                .DisplayIndex = 7
                .DataPropertyName = "Cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colCantidad)

            Dim colNroSobres As New DataGridViewTextBoxColumn
            With colNroSobres
                .DisplayIndex = 8
                .DataPropertyName = "NroSobres"
                .HeaderText = "NroSobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colNroSobres)


            Dim colProcedencia As New DataGridViewTextBoxColumn
            With colProcedencia
                .DisplayIndex = 9
                .DataPropertyName = "Procedencia"
                .HeaderText = "Procedencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colProcedencia)

            Dim coldireccion As New DataGridViewTextBoxColumn
            With coldireccion
                .DisplayIndex = 10
                .DataPropertyName = "direccion"
                .HeaderText = "direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(coldireccion)

            Dim colAtendido As New DataGridViewTextBoxColumn
            With colAtendido
                .DisplayIndex = 11
                .DataPropertyName = "Atendido"
                .HeaderText = "Atendido"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colAtendido)

            Dim colnro_unidad_transporte As New DataGridViewTextBoxColumn
            With colnro_unidad_transporte
                .DisplayIndex = 12
                .DataPropertyName = "nro_unidad_transporte"
                .HeaderText = "Nro_Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colnro_unidad_transporte)

            Dim colResponsable_Movil As New DataGridViewTextBoxColumn
            With colResponsable_Movil
                .DisplayIndex = 13
                .DataPropertyName = "Responsable_Movil"
                .HeaderText = "Responsable_Movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colResponsable_Movil)

            Dim colHoraOperacion As New DataGridViewTextBoxColumn
            With colHoraOperacion
                .DisplayIndex = 14
                .DataPropertyName = "HoraOperacion"
                .HeaderText = "HoraOperacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colHoraOperacion)

            Dim colNombre_entrega As New DataGridViewTextBoxColumn
            With colNombre_entrega
                .DisplayIndex = 15
                .DataPropertyName = "Nombre_entrega"
                .HeaderText = "Nombre_entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colNombre_entrega)

            Dim colhora_entrega As New DataGridViewTextBoxColumn
            With colhora_entrega
                .DisplayIndex = 16
                .DataPropertyName = "hora_entrega"
                .HeaderText = "hora_entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colhora_entrega)


            Dim colEstado_Envio As New DataGridViewTextBoxColumn
            With colEstado_Envio
                .DisplayIndex = 17
                .DataPropertyName = "Estado_Envio"
                .HeaderText = "Estado_Envio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colEstado_Envio)

            Dim colOBS As New DataGridViewTextBoxColumn
            With colOBS
                .DisplayIndex = 18
                .DataPropertyName = "OBS"
                .HeaderText = "OBS"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colOBS)

            Dim colTipo_Observacion As New DataGridViewTextBoxColumn
            With colTipo_Observacion
                .DisplayIndex = 19
                .DataPropertyName = "Tipo_Observacion"
                .HeaderText = "Tipo_Observacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colTipo_Observacion)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            ObjEntrega_Recojo.v_FECHA_INICIO = dtFechaInicio.Text
            ObjEntrega_Recojo.v_FECHA_FIN = dtFechaFin.Text
            ObjEntrega_Recojo.v_RUC_RAZONSOCIAL = IIf(txtBuscarRasonSocial.Text <> "", txtBuscarRasonSocial.Text, "%")
            ObjEntrega_Recojo.v_idProcedencia = ObjFiltrosEntregaRecojos.coll_Procedencia.Item(cmdProcedencia.SelectedIndex.ToString())
            ObjEntrega_Recojo.v_IDESTADO_DOCUMENTO = ObjFiltrosEntregaRecojos.coll_Lista_Estados.Item(cmbEstados.SelectedIndex.ToString)
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            ObjEntrega_Recojo.fnLISTA_ENTREGAS_RECOJOS()
            'If ObjEntrega_Recojo.fnLISTA_ENTREGAS_RECOJOS() = False Then
            '    MsgBox("ingreso...")
            'End If
            'rst = ObjEntrega_Recojo.cur_datos
            'daControl_FAC.Fill(dtControl_FAC, rst)

            dtControl_FAC.Clear()
            dtGridViewControl_FACBOL.Refresh()
            '
            dtControl_FAC = ObjEntrega_Recojo.dt_cur_datos
            dvControl_FAC = dtControl_FAC.DefaultView
            bformatImage = True
            dtGridViewControl_FACBOL.DataSource = dvControl_FAC
            dtGridViewControl_FACBOL.Refresh()
            dtGridViewControl_FACBOL.Update()
            lbNroRegistro.Text = dvControl_FAC.Count
            If dvControl_FAC.Count = 0 Then
                MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try        
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_FACBOL.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Integer
                    If e.RowIndex >= 0 And dtGridViewControl_FACBOL.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(IDGRIESTADO_REG).Value) = False Then
                            IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(IDGRIESTADO_REG).Value
                            dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(1).Tag = 1
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 27
                                e.Value = bmpFACTURA_EMITIDA
                            Case 2
                                e.Value = bmpFACTURA_ANULADA
                            Case 29
                                e.Value = bmpFACTURA_DEVUELTA
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
                dtGridViewControl_FACBOL.Update()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub mnuAsignarControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAsignarControl.Click
        Try
            Dim FrmObj As New FrmAsociacionMovil
            Acceso.Asignar(FrmObj, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If FrmObj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    For i As Integer = 0 To dtGridViewControl_FACBOL.Rows.Count - 1
                        If dtGridViewControl_FACBOL.Item(3, i).Value = 1 Then
                            ObjEntrega_Recojo.v_idTipo_Comprobante = dtGridViewControl_FACBOL.Item(1, i).Value
                            ObjEntrega_Recojo.v_idComprobante = dtGridViewControl_FACBOL.Item(2, i).Value
                            ObjEntrega_Recojo.v_IDCONTROL = 1
                            ObjEntrega_Recojo.v_serie = "00"
                            ObjEntrega_Recojo.v_nroDoc = "00"
                            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                            Dim ldt_tmp As New DataTable
                            ldt_tmp = ObjEntrega_Recojo.fnASOCIAR_MOVIL_ENTREGA()
                        End If
                    Next
                    MsgBox("Asociado Correctamente...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            FrmObj = Nothing

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtGridViewControl_FACBOL_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                MnuControlUsuario.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregar.Click, btnMovil.Click
        Try
            Dim ObjFrm As New FrmListaSolicitudesEntregas
            'ObjFrm.ShowDialog()
            Acceso.Asignar(ObjFrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjFrm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjFrm = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub SeleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        Try
            Dim drv As DataRowView
            Dim dr, dr1, dr2, dr3, dr4, dr5 As Object
            For i As Integer = 0 To dtGridViewControl_FACBOL.Rows.Count - 1
                'dr = dtGridViewControl_FACBOL.Item(1, i).Value
                'dr1 = dtGridViewControl_FACBOL.Item(2, i).Value
                'dr2 = dtGridViewControl_FACBOL.Item(3, i).Value
                'dr3 = dtGridViewControl_FACBOL.Item(4, i).Value
                'dr4 = dtGridViewControl_FACBOL.Item(5, i).Value
                'dr5 = dtGridViewControl_FACBOL.Item(6, i).Value
                dtGridViewControl_FACBOL.Item(3, i).Value = 1
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DesmarcarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesmarcarTodosToolStripMenuItem.Click
        Try
            Dim drv As DataRowView
            For i As Integer = 0 To dtGridViewControl_FACBOL.Rows.Count - 1
                dtGridViewControl_FACBOL.Item(3, i).Value = 0
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
   
  

End Class
