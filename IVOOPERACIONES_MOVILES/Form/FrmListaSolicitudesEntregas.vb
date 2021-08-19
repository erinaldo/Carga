Public Class FrmListaSolicitudesEntregas

    Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView

    Dim bformatImage As Boolean = True
    Dim ObjEntrega_Recojo As New dtoEntrega_Recojo
    Dim id_columEstado As Integer = 3
    Dim IDGRIESTADO_REG As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmListaSolicitudesEntregas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmListaSolicitudesEntregas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lidrol As Long
        Dim flag As Boolean = False
        Dim ldt_tmp As DataTable
        Try
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha
            If ObjFiltrosEntregaRecojos.fnLISTA_SINO_TIPO_MOVIL() = False Then
                'rst = ObjFiltrosEntregaRecojos.CUR_DATOS
                '
                ldt_tmp = ObjFiltrosEntregaRecojos.fnSP_LISTAR_AGENCIAS()

                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(0), cmbResponsableMovil, ObjFiltrosEntregaRecojos.coll_Responsables, 0)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(1), cmbAtendido, ObjFiltrosEntregaRecojos.coll_Atendido, 0)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(2), cmbTipoOperacion, ObjFiltrosEntregaRecojos.coll_Tipo_OPeracion, 0)
                '
                'ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.fnSP_LISTAR_AGENCIAS, cmbAgencias, ObjFiltrosEntregaRecojos.coll_Control_Agencias, dtoUSUARIOS.m_idciudad)
                '
                ModuUtil.LlenarComboIDs_dt(ldt_tmp, cmbAgencias, ObjFiltrosEntregaRecojos.coll_Control_Agencias, dtoUSUARIOS.m_idciudad)
                '
                'Recuperando el rol del usuario 
                '
                lidrol = dtoUSUARIOS.IdRol
                '                
                'If fnValidar_Rol("3") Or fnValidar_Rol("4") Then
                'If fnValidar_Rol("100") Then
                'bloque
                If Acceso.SiRol(G_Rol, Me, 1) Then
                    flag = True
                End If
            End If
            'Verifica que el rol del usuario le permita navegar por todas las agencias y asociar a los usuarios respectivos  
            'If fnValidar_Rol("35") = True Then 'Supervisor Moviles- Finalidad que s pueda cambiar si afectar la operación                 
            ' Debe recuperar todo los reponsables de entregar los bultos por agencia                 
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                flag = True
            End If
            If flag = False Then
                cmbAgencias.Enabled = False
            Else
                dtoUSUARIOS.IdRol = lidrol
            End If
            Load_Grid()

            Me.EstadoGrid()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Dim j As String = Me.hnd
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

            'Me.MnuControlUsuario.Items("ImprimirManifiestoToolStripMenuItem").Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
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

            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "Codigo"
                .Name = "Codigo"
                .HeaderText = "Codigo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colID)

            Dim colAtendido As New DataGridViewTextBoxColumn
            With colAtendido
                .Name = "atendido"
                .DisplayIndex = 2
                .DataPropertyName = "Atendido"
                .HeaderText = "Atendido"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colAtendido)

            Dim colTipo_Operacion As New DataGridViewTextBoxColumn
            With colTipo_Operacion
                .DisplayIndex = 3
                .DataPropertyName = "Tipo_Operacion"
                .HeaderText = "Tipo_Operacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(colTipo_Operacion)


            Dim colIdtipo_Comprobante As New DataGridViewTextBoxColumn
            With colIdtipo_Comprobante
                .DisplayIndex = 4
                .DataPropertyName = "Idtipo_Comprobante"
                .HeaderText = "Idtipo_Comprobante"
                .Name = "Idtipo_Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colIdtipo_Comprobante)

            Dim colIdcomprobante As New DataGridViewTextBoxColumn
            With colIdcomprobante
                .DisplayIndex = 5
                .DataPropertyName = "Idcomprobante"
                .HeaderText = "Idcomprobante"
                .Name = "Idcomprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colIdcomprobante)
            '
        Catch ex As Exception

        End Try
    End Sub
    Public Sub fnBuscarListaEntregasRecojo()
        Try
            ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_FECHA_INICIO = dtFechaInicio.Text
            ObjEntrega_Recojo.v_FECHA_FIN = dtFechaFin.Text
            '
            ObjEntrega_Recojo.v_IDTIPO_OPERACION = ObjFiltrosEntregaRecojos.coll_Tipo_OPeracion.Item(cmbTipoOperacion.SelectedIndex.ToString)
            '
            If ObjEntrega_Recojo.fnLISTA_ENTREGAS_RECOJO() = True Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                'rst = ObjEntrega_Recojo.cur_datos
                'daControl_FAC.Fill(dtControl_FAC, rst)
                '
                dtControl_FAC.Clear()
                dtGridViewControl_FACBOL.Refresh()
                '
                dtControl_FAC = ObjEntrega_Recojo.dt_cur_datos
                '
                dvControl_FAC = dtControl_FAC.DefaultView
                bformatImage = True
                dtGridViewControl_FACBOL.DataSource = dvControl_FAC
                dtGridViewControl_FACBOL.Refresh()
                dtGridViewControl_FACBOL.Update()
                lbNroRegistro.Text = dvControl_FAC.Count
                If dvControl_FAC.Count = 0 Then
                    MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            fnBuscarListaEntregasRecojo()
            Me.EstadoGrid()
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

                If txtNroMovil.Focused = True Then
                    fnBuscarDatos(3)
                    SendKeys.Send("{Tab}")
                ElseIf txtNroSolicitud.Focused = True Then
                    fnBuscarDatos(2)
                    SendKeys.Send("{Tab}")
                ElseIf txtNroSerieDoc.Focused = True Then
                    fnBuscarDatos(1)
                Else
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then

                End If
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                Try
                    rpt_manifiesto()
                    'ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
                    'ObjEntrega_Recojo.v_FECHA_INICIO = dtFechaInicio.Text
                    'ObjEntrega_Recojo.v_FECHA_FIN = dtFechaFin.Text
                    'Dim ObjReport As New ClsLbTepsa.dtoFrmReport
                    'ObjReport.rutaRpt = PathFrmReport
                    'ObjReport.conectar(rptservice, rptuser, rptpass)
                    'ObjReport.printrptB(False, "", "MOV004.rpt", "v_idresponsable;" & ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE, "v_fecha_Inicial;" & ObjEntrega_Recojo.v_FECHA_INICIO, "v_fecha_Final;" & ObjEntrega_Recojo.v_FECHA_FIN)
                    'ClsLbTepsa.dtoFrmReport.rutaRpt = PathFrmReport
                    'ClsLbTepsa.dtoFrmReport.conectar(rptservice, rptuser, rptpass)
                    '    'ClsLbTepsa.dtoFrmReport.printrpt(False, "", "MOV004.rpt", )
                Catch ex As Exception
                    MsgBox("Revice sus Datos...", MsgBoxStyle.Information, "Seguridad Sistema")
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                    Try
                        If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                            Return flat
                        End If
                        Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
                        If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                            Return flat
                        End If

                        ObjEditarDatosDocumentos.v_idSolicitud = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
                        ObjEditarDatosDocumentos.v_idcomprobante = dtGridViewControl_FACBOL.Rows(row).Cells(6).Value
                        ObjEditarDatosDocumentos.v_idtip_comprobante = dtGridViewControl_FACBOL.Rows(row).Cells(5).Value

                        Dim objFrm As New FrmEditarDatosDocumentos
                    'objFrm.ShowDialog()
                    Acceso.Asignar(objFrm, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        objFrm.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    objFrm = Nothing

                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                Try
                    Dim ObjMSM2Movil As New FrmMSM2Movil
                    ObjMSM2Movil.idusuario = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
                    'ObjMSM2Movil.ShowDialog()
                    Acceso.Asignar(ObjMSM2Movil, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ObjMSM2Movil.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ObjMSM2Movil = Nothing

                Catch ex As Exception

                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                    Try
                        Dim ObjFormAtencionCliente As New FrmAtencionCliente
                    'ObjFormAtencionCliente.ShowDialog()
                    Acceso.Asignar(ObjFormAtencionCliente, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ObjFormAtencionCliente.ShowDialog()
                        fnBuscarListaEntregasRecojo()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ObjFormAtencionCliente = Nothing
                Catch ex As Exception
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                Try
                    Dim ObjListaGuiasEnvio As New FrmListaGuiasEnvio
                    If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                        Return flat
                    End If
                    Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
                    If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                        Return flat
                    End If
                    ObjListaGuiasEnvio.CODIGO_Solitud = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
                    'ObjListaGuiasEnvio.ShowDialog()
                    Acceso.Asignar(ObjListaGuiasEnvio, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ObjListaGuiasEnvio.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ObjListaGuiasEnvio = Nothing
                Catch ex As Exception
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F10 Then
                    Try

                        Dim flag As Boolean = False
                    'If fnValidar_Rol("31") Then 'Jefe de Area de Sistemas....
                    'bloque
                    If Acceso.SiRol(G_Rol, Me, 3) Then
                        flag = True
                    End If
                    If flag = False Then
                        MsgBox("Usted no tiene Acceso, No es Jefe de Area de Moviles...", MsgBoxStyle.Information, "Seguridad Sistema")
                        Exit Function
                    End If
                    If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                        Return flat
                    End If
                    Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
                    If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                        Return flat
                    End If
                    ObjEntrega_Recojo.v_idSolicitudEntrega = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value

                    Dim ObjReasignacionMovil As New frmReasignacionMovil
                    ObjReasignacionMovil.v_idSolicitudEntrega = ObjEntrega_Recojo.v_idSolicitudEntrega
                    'ObjReasignacionMovil.ShowDialog()
                    Acceso.Asignar(ObjReasignacionMovil, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ObjReasignacionMovil.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ObjReasignacionMovil = Nothing
                Catch ex As Exception
                    MsgBox("Revice sus datos", MsgBoxStyle.Information, "Seguridad Sistemas")
                End Try
            ElseIf msg.WParam.ToInt32 = Keys.F11 Then

                Try
                    Dim flag As Boolean = False
                    'If fnValidar_Rol("31") Then 'Jefe de Area de Sistemas....
                    'bloque
                    If Acceso.SiRol(G_Rol, Me, 4) Then
                        flag = True
                    End If
                    If flag = False Then
                        MsgBox("Usted no tiene Acceso, No es Jefe de Area de Moviles...", MsgBoxStyle.Information, "Seguridad Sistema")
                        Exit Function
                    End If
                    Dim ObjListaRecojosProgramados As New FrmListaRecojosProgramados
                    'ObjListaRecojosProgramados.ShowDialog()
                    Acceso.Asignar(ObjListaRecojosProgramados, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ObjListaRecojosProgramados.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ObjListaRecojosProgramados = Nothing
                Catch ex As Exception
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
   
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            fnBuscarDatos(1)
            Me.EstadoGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fnBuscarDatos(ByVal index As Integer)
        Try

            If index = 1 Then
                Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
                If strNroDoc.Length > 1 Then
                    If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                        ObjEntrega_Recojo.v_serie = strNroDoc(0)
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(1)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                Else
                    If strNroDoc.Length = 1 Then
                        ObjEntrega_Recojo.v_serie = "-1"
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(0)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                End If
            End If
            ObjEntrega_Recojo.v_idTipo_Comprobante = 0
            ObjEntrega_Recojo.v_idComprobante = 0
            ObjEntrega_Recojo.v_IDCONTROL = 2
            ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_idtipoOPeracion = ObjFiltrosEntregaRecojos.coll_Tipo_OPeracion.Item(cmbTipoOperacion.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_Atendido = ObjFiltrosEntregaRecojos.coll_Atendido.Item(cmbAtendido.SelectedIndex.ToString)
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            'rst = ObjEntrega_Recojo.cur_datos
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjEntrega_Recojo.fnASOCIAR_MOVIL_ENTREGA()
            'If ObjEntrega_Recojo.cur_datos.EOF = False And ObjEntrega_Recojo.cur_datos.BOF = False Then
            If ldt_tmp.Rows.Count > 0 Then
                If ldt_tmp.Rows(0).Item("flag") <> 0 Then
                    MsgBox(ldt_tmp.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                    Me.txtNroSerieDoc.Text = ""
                    Exit Sub
                Else
                    txtNroSerieDoc.Text = ""
                    ObjEntrega_Recojo.v_idTipo_Comprobante = ldt_tmp.Rows(0).Item("idTipoComprobante")
                    ObjEntrega_Recojo.v_idComprobante = ldt_tmp.Rows(0).Item("idComprobante")
                    Try
                        ObjWebService.fnWebService(ObjEntrega_Recojo.v_idTipo_Comprobante, ObjEntrega_Recojo.v_idComprobante.ToString(), 47)
                    Catch ex As Exception

                    End Try
                End If
                'If ObjEntrega_Recojo.cur_datos.Fields.Item("flag").Value <> 0 Then
                '    MsgBox(ObjEntrega_Recojo.cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
                '    Me.txtNroSerieDoc.Text = ""
                '    Exit Sub
                'Else
                '    txtNroSerieDoc.Text = ""
                '    ObjEntrega_Recojo.v_idTipo_Comprobante = ObjEntrega_Recojo.cur_datos.Fields.Item("idTipoComprobante").Value
                '    ObjEntrega_Recojo.v_idComprobante = ObjEntrega_Recojo.cur_datos.Fields.Item("idComprobante").Value
                '    Try
                '        ObjWebService.fnWebService(ObjEntrega_Recojo.v_idTipo_Comprobante, ObjEntrega_Recojo.v_idComprobante.ToString(), 47)
                '    Catch ex As Exception
                '    End Try
                'End If
            End If
            fnBuscarListaEntregasRecojo()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub mnuAnulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAnulacion.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjEntrega_Recojo.v_idSolicitudEntrega = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            ObjEntrega_Recojo.fnCANCELACION_ENTREGA()
            '
            'If ObjEntrega_Recojo.cur_datos.EOF = False And ObjEntrega_Recojo.cur_datos.BOF = False Then
            '    MsgBox(ObjEntrega_Recojo.cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportarExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dtGridViewControl_FACBOL)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles dtGridViewControl_FACBOL.CellToolTipTextNeeded
        Try
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim ide As New Object
                ide = dtGridViewControl_FACBOL.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value
                'ide = dtGridViewControl_FACBOL.Rows(e.RowIndex).DataGridView(3, e.RowIndex).Value
                If ide = "NO" Or ide = "N" Then
                    e.ToolTipText = "REPARTO/ACTIVO"
                ElseIf ide = "SI" Or ide = "S" Then
                    e.ToolTipText = "ENTREGADO"
                End If
                'If IsNothing(ide) = False Or Len(dtGridViewControl_FACBOL.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value.ToString) > 0 Then
                '    'Dim var As String = CargaTxtCmb(Me.cmbEstadoRegistro, ModVOESPECIESVALORADAS.IDEstadoRegistro, ide)
                '    If ide = 1 Then
                '        e.ToolTipText = "ACTIVO"
                '    ElseIf ide = 2 Then
                '        e.ToolTipText = "ANULADO"
                '    ElseIf ide = 3 Then
                '        e.ToolTipText = "ELIMINADO"
                '    ElseIf ide = 9 Then
                '        e.ToolTipText = "INACTIVO"
                '    ElseIf ide = 18 Then
                '        e.ToolTipText = "RECEPCIONADO"
                '    ElseIf ide = 19 Then
                '        e.ToolTipText = "DESPACHADO"
                '    ElseIf ide = 20 Then
                '        e.ToolTipText = "LLEGADA"
                '    ElseIf ide = 21 Then
                '        e.ToolTipText = "ENTREGADO"
                '    ElseIf ide = 22 Then
                '        e.ToolTipText = "CARGO"
                '    ElseIf ide = 23 Then
                '        e.ToolTipText = "LIQUIDADO"
                '    ElseIf ide = 24 Then
                '        e.ToolTipText = "PENDIENTE"
                '    ElseIf ide = 25 Then
                '        e.ToolTipText = "PERDIDO"
                '    Else
                '        e.ToolTipText = "NO DEFINIDO"
                '    End If
                'End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_FACBOL.CellFormatting
        Dim strvar As String = ""
        'Try
        '    If bformatImage = True Then
        '        Dim ide As New Object
        '        ide = dtGridViewControl_FACBOL.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value
        '        'ide = dtGridViewControl_FACBOL.Rows(e.RowIndex).DataGridView(3, e.RowIndex).Value
        '        If ide = "NO" Or ide = "N" Then
        '            e.Value = C_RECEPCIONADO
        '        ElseIf ide = "SI" Or ide = "S" Then
        '            e.Value = C_ENTREGADO
        '        End If
        '    End If

        'Catch ex As Exception

        'End Try
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Object
                    If e.RowIndex >= 0 And dtGridViewControl_FACBOL.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(id_columEstado).Value) = False Then
                            IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(id_columEstado).Value
                            dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(1).Tag = 1
                        Else
                            IdEstado = "NO"
                        End If

                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case "S"
                                e.Value = C_ENTREGADO
                            Case "SI"
                                e.Value = C_ENTREGADO
                            Case "NO"
                                e.Value = C_RECEPCIONADO
                            Case "N"
                                e.Value = C_RECEPCIONADO
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

    Private Sub ConfirmacionEntregasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmacionEntregasToolStripMenuItem.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If

            ObjEntrega_Recojo.v_idSolicitudEntrega = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value

            Dim Objfrm As New frmConfirmarEntregas
            Objfrm.v_idSolicitud_Entrega = ObjEntrega_Recojo.v_idSolicitudEntrega

            Objfrm.rows = Me.dtGridViewControl_FACBOL.SelectedRows


            Objfrm.v_idTipo_Comprobante = dtGridViewControl_FACBOL.Rows(row).Cells("Idtipo_Comprobante").Value
            Objfrm.v_idComprobante = dtGridViewControl_FACBOL.Rows(row).Cells("Idcomprobante").Value

            'Objfrm.ShowDialog()

            Acceso.Asignar(Objfrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Objfrm.ShowDialog()
                btnBuscar_Click(sender, e)
            Else
                MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Objfrm = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ImprimirManifiestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirManifiestoToolStripMenuItem.Click
        Try
            'cambio tecla funcion
            If Me.btnImprimir.Enabled Then
                rpt_manifiesto()
            End If
            'ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
            'ObjEntrega_Recojo.v_FECHA_INICIO = dtFechaInicio.Text
            'ObjEntrega_Recojo.v_FECHA_FIN = dtFechaFin.Text
            'Dim ObjReport As New ClsLbTepsa.dtoFrmReport
            'ObjReport.rutaRpt = PathFrmReport
            'ObjReport.conectar(rptservice, rptuser, rptpass)
            ''ObjReport.printrptB(False, "", "MOV004.rpt", "v_idresponsable;" & ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE, "v_fecha_Inicial;" & ObjEntrega_Recojo.v_FECHA_INICIO, "v_fecha_Final;" & ObjEntrega_Recojo.v_FECHA_FIN)
            'ObjReport.printrptB(False, "", "MOV020.rpt", "v_idresponsable;" & ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE, "v_fecha_Inicial;" & ObjEntrega_Recojo.v_FECHA_INICIO, "v_fecha_Final;" & ObjEntrega_Recojo.v_FECHA_FIN)
            ''ClsLbTepsa.dtoFrmReport.rutaRpt = PathFrmReport
            ''ClsLbTepsa.dtoFrmReport.conectar(rptservice, rptuser, rptpass)
            ''ClsLbTepsa.dtoFrmReport.printrpt(False, "", "MOV004.rpt", )
        Catch ex As Exception
            MsgBox("Revise sus Datos...", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub cmbAgencias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencias.SelectedIndexChanged
        Dim ldt_tmp As New DataTable
        Try
            ObjFiltrosEntregaRecojos.v_iCiudad = Int(ObjFiltrosEntregaRecojos.coll_Control_Agencias.Item(cmbAgencias.SelectedIndex.ToString))
            If ObjFiltrosEntregaRecojos.v_iCiudad >= 0 Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                ldt_tmp = ObjFiltrosEntregaRecojos.fnSP_CONTROL_RESPONSABLES()
                ModuUtil.LlenarComboIDs_dt(ldt_tmp, cmbResponsableMovil, ObjFiltrosEntregaRecojos.coll_Responsables, 0)
                '
            Else
                cmbResponsableMovil.Controls.Clear()
                cmbResponsableMovil.Items.Clear()
                ObjFiltrosEntregaRecojos.coll_Responsables.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub RepartoParcialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepartoParcialToolStripMenuItem.Click
        Dim s_idnro_recojo As String
        Dim flag As Boolean = False
        Try

            'If fnValidar_Rol("31") Then 'Jefe de Area de Sistemas....
            'bloque
            If Acceso.SiRol(G_Rol, Me, 7) Then
                flag = True
            End If
            If flag = False Then
                MsgBox("Usted no tiene Acceso, No es Jefe de Area de Moviles...", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            '--
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            '-
            Dim ObjListaRecojosProgramados As New frm_reparto_parcial
            ObjListaRecojosProgramados.ps_idsolicitud_recojo_carga = CType(dtGridViewControl_FACBOL.Rows(row).Cells(2).Value, String)
            ObjListaRecojosProgramados.pb_idusuario_responsable = CType(ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString), Long)
            Acceso.Asignar(ObjListaRecojosProgramados, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjListaRecojosProgramados.ShowDialog()
                If ObjListaRecojosProgramados.pb_cancelar = False Then
                    'Debe recupera de nuevo los datos
                    fnBuscarListaEntregasRecojo()
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjListaRecojosProgramados = Nothing

        Catch ex As Exception

        End Try
    End Sub
    Sub rpt_manifiesto()
        Dim ObjReport As New ClsLbTepsa.dtoFrmReport
        Try
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE = ObjFiltrosEntregaRecojos.coll_Responsables.Item(cmbResponsableMovil.SelectedIndex.ToString)
            ObjEntrega_Recojo.v_FECHA_INICIO = dtFechaInicio.Text
            ObjEntrega_Recojo.v_FECHA_FIN = dtFechaFin.Text
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            'ObjReport.printrptB(False, "", "MOV004.rpt", "v_idresponsable;" & ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE, "v_fecha_Inicial;" & ObjEntrega_Recojo.v_FECHA_INICIO, "v_fecha_Final;" & ObjEntrega_Recojo.v_FECHA_FIN)
            ObjReport.printrptB(False, "", "MOV020.rpt", "v_idresponsable;" & ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE, "v_fecha_Inicial;" & ObjEntrega_Recojo.v_FECHA_INICIO, "v_fecha_Final;" & ObjEntrega_Recojo.v_FECHA_FIN)
            'ClsLbTepsa.dtoFrmReport.rutaRpt = PathFrmReport
            'ClsLbTepsa.dtoFrmReport.conectar(rptservice, rptuser, rptpass)
            'ClsLbTepsa.dtoFrmReport.printrpt(False, "", "MOV004.rpt", )

            'hlamas 13-03-2015
            'Agrega hora de emision a hoja de ruta
            'Dim obj As New dtoSolicitudRecojoEntrega
            'obj.HojaRutaEmision(dtFechaInicio.Text, dtFechaFin.Text, ObjEntrega_Recojo.v_IDUSUARIO_RESPONSABLE)

        Catch ex As Exception
            MsgBox("Revise sus Datos...", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        rpt_manifiesto()
    End Sub

    Sub Editar()
        Try
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
            '    Return
            'End If
            'Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    Return
            'End If

            'ObjEditarDatosDocumentos.v_idSolicitud = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            'ObjEditarDatosDocumentos.v_idcomprobante = dtGridViewControl_FACBOL.Rows(row).Cells(6).Value
            'ObjEditarDatosDocumentos.v_idtip_comprobante = dtGridViewControl_FACBOL.Rows(row).Cells(5).Value

            Dim objFrm As New FrmEditarDatosDocumentos
            'objFrm.ShowDialog()

            Acceso.Asignar(objFrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                objFrm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            objFrm = Nothing

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Sub ver()
        Try
            Dim ObjListaGuiasEnvio As New FrmListaGuiasEnvio
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If

            ObjListaGuiasEnvio.CODIGO_Solitud = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            'ObjListaGuiasEnvio.ShowDialog()

            Acceso.Asignar(ObjListaGuiasEnvio, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjListaGuiasEnvio.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjListaGuiasEnvio = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Sub EstadoGrid()
        Return
        If dtGridViewControl_FACBOL.Rows.Count = 0 Then
            Me.grbOpcion.Enabled = False
        Else
            If IsNothing(dtGridViewControl_FACBOL.Rows(0).Cells(1).Value) Then
                Me.grbOpcion.Enabled = False
            Else
                Me.grbOpcion.Enabled = True
            End If
        End If
    End Sub

    Private Sub dtGridViewControl_FACBOL_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If dtGridViewControl_FACBOL.CurrentRow.Cells("atendido").Value.ToString.Substring(0, 1) = "S" Then
                    MnuControlUsuario.Items("ConfirmacionEntregasToolStripMenuItem").Visible = False
                Else
                    MnuControlUsuario.Items("ConfirmacionEntregasToolStripMenuItem").Visible = True
                End If
                MnuControlUsuario.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As frmReparto = New frmReparto
            frm.StartPosition = FormStartPosition.Manual
            'frm.WindowState = FormWindowState.Normal
            'frm.Width = 1360
            'frm.Height = 685
            frm.ControlBox = True
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Principal
                'frm.hnd = Hnd
                frm.Show()
            Else
                Cursor = Cursors.Default
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub grbOpcion_Enter(sender As System.Object, e As System.EventArgs) Handles grbOpcion.Enter

    End Sub

    Private Sub txtNroSerieDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroSerieDoc.KeyPress
        If Asc(e.KeyChar) <> Keys.Enter Then
            If ValidaNumero2(e.KeyChar) Then
                e.Handled = False
            ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNroSerieDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroSerieDoc.TextChanged

    End Sub
End Class