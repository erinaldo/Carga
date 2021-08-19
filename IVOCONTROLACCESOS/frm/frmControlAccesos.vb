Public Class frmControlAccesos
    'Dim da, darol As New OleDb.OleDbDataAdapter
    Dim dt, dtrol As New System.Data.DataTable
    Dim dv, dvrol As System.Data.DataView
    Public ListRoles As New Collection
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmControlAccesos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmControlAccesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ShadowLabel1.Text = "Control Accesos al Sistema"
            MenuTab.Items(0).Text = "Busqueda Control"
            MenuTab.Items(1).Text = "Mantenimiento Controles"
            MenuTab.Items(2).Text = ""
            ModuUtil.LlenarTreeListViewCtrl(dtoCONTROL_ACCESOS.Listar_Form(), Me.TreeLista, "MODULOS")
            TreeLista.ExpandAll()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub chboxTodos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chboxTodos.CheckedChanged
        Call GetControl()
    End Sub

    Private Sub chboxTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chboxTodos.Click
        Call GetControl()
    End Sub
    Private Sub GetControl()
        Try
            'chboxTodos.Update()
            If chboxTodos.Checked = True Then
                GroupBoxTOOL.Enabled = False
                Me.chboxAyuda.Checked = True
                Me.chboxCancelar.Checked = True
                Me.chboxEliminar.Checked = True
                Me.chboxExportarExcel.Checked = True
                Me.chboxExportarPDF.Checked = True
                Me.chboxExportarWork.Checked = True
                Me.chboxGrabar.Checked = True
                Me.chboxNuevo.Checked = True
                Me.chboxEditar.Checked = True
                Me.chboxImprimir.Checked = True
                Me.chboxEMAIL.Checked = True
            Else
                GroupBoxTOOL.Enabled = True
                Me.chboxAyuda.Checked = False
                Me.chboxCancelar.Checked = False
                Me.chboxEliminar.Checked = False
                Me.chboxExportarExcel.Checked = False
                Me.chboxExportarPDF.Checked = False
                Me.chboxExportarWork.Checked = False
                Me.chboxGrabar.Checked = False
                Me.chboxNuevo.Checked = False
                Me.chboxEditar.Checked = False
                Me.chboxImprimir.Checked = False
                Me.chboxEMAIL.Checked = False
            End If
            chboxTodos.Update()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad sistema")
        End Try
    End Sub

    Private Sub chboxTodos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chboxTodos.KeyUp
        Call GetControl()
    End Sub
    Dim objNMode As New Object
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Try
            'datahelper
            'dt.Clear()
            'rst = Nothing
            'objNMode = e.Node()
            'rst = dtoCONTROL_ACCESOS.Listar_Formulario_Roles(e.Node().Text)
            'lbFrmRol.Text = e.Node().Text.ToString()
            'da.Fill(dt, rst)
            'dv = dt.DefaultView
            dt.Clear()
            dt = dtoCONTROL_ACCESOS.Listar_Formulario_Roles(e.Node().Text)
            dv = dt.DefaultView

            DataGridViewRolFrm.DataSource = dv
            DataGridViewRolFrm.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            DataGridViewRolFrm.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            DataGridViewRolFrm.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            DataGridViewRolFrm.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            DataGridViewRolFrm.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            DataGridViewRolFrm.Columns(4).Visible = False
            EdicionToolStripMenuItem.Enabled = False
            'DataGridViewRolFrm.Columns(1).Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub TreeLista_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeLista.KeyUp
        Try
            If e.KeyData.ToString() = Keys.F1.ToString() Then
                Call NuevoForm()
            End If
            If e.KeyData.ToString() = Keys.F2.ToString() Then
                EditarForm()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Segurida Sistema")
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Call NuevoForm()
    End Sub
    Private Sub NuevoForm()
        Try
            dtoForm.IDCONTROL = 1 'Estado de 1 para la insercion y 0 para la actualizacion
            If TreeLista.SelectedNode().Tag > 0 Then
                dtoForm.IDMODULO_SISTEMA = TreeLista.SelectedNode().Tag
                Dim fdlg As New frmMantenimientoForm
                fdlg.ShowDialog()
                If fdlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    ModuUtil.LlenarTreeListViewCtrl(dtoCONTROL_ACCESOS.Listar_Form(), Me.TreeLista, "MODULOS")
                    TreeLista.ExpandAll()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Private Sub EliminarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem1.Click
    '    Try
    '        If TreeLista.SelectedNode().Tag > 0 Then
    '            TreeLista.Nodes(TreeLista.SelectedNode.Index).Remove()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Call EditarForm()
    End Sub
    Private Sub EditarForm()
        Try
            dtoForm.IDCONTROL = 2 'Estado de 1 para la insercion y 0 para la actualizacion
            If TreeLista.SelectedNode().Tag = 0 Then
                Dim str As String
                str = TreeLista.SelectedNode().Text
                dtoForm.Listar_Datos_Form(str)
                Dim fdlg As New frmMantenimientoForm
                fdlg.ShowDialog()
                If fdlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    ModuUtil.LlenarTreeListViewCtrl(dtoCONTROL_ACCESOS.Listar_Form(), Me.TreeLista, "MODULOS")
                    TreeLista.ExpandAll()
                End If
            Else
                MsgBox("no Puede Editar un Proceso, son Unicos", MsgBoxStyle.Critical, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub TreeLista_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeLista.ContextMenuChanged
        Try
            ContextMenuStrip1.Show(sender, TreeLista.Location())
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub TreeLista_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeLista.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip1.Show(sender, e.X, e.Y)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnFiltroRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltroRoles.Click
        Try
            Dim vfrm As New frmFiltroRoles()
            Acceso.Asignar(vfrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                vfrm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim item As Integer
            item = 0
            If ListRoles.Count > 0 Then
                dtoUSUARIOS.idListRoles = ""
                For Each thisObject As dtoCONTROLUSUARIOS In ListRoles
                    item = item + 1
                    Dim row0 As String() = {thisObject.IdRol.ToString(), thisObject.Rol.ToString()}
                    If item = ListRoles.Count Then
                        dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString()
                    Else
                        dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString() & ","
                    End If
                    DataGridViewRoles.Rows().Add(row0)
                Next thisObject
                'DataGridViewRoles.Columns(1).Visible = False
            End If
            DataGridViewRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub ChBoxTab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxTab.CheckedChanged
        Call GetControlTAB()
    End Sub
    Public Sub GetControlTAB()
        Try
            If ChBoxTab.Checked = True Then
                GroupBoxTAB.Enabled = False
                ChboxTab01.Checked = True
                ChboxTab02.Checked = True
                ChboxTab03.Checked = True
                ChboxTab04.Checked = True
                ChboxTab05.Checked = True
                ChboxTab06.Checked = True
                ChboxTab07.Checked = True
                ChboxTab08.Checked = True
                ChboxTab09.Checked = True
                ChboxTab10.Checked = True
            Else
                GroupBoxTAB.Enabled = True
                ChboxTab01.Checked = False
                ChboxTab02.Checked = False
                ChboxTab03.Checked = False
                ChboxTab04.Checked = False
                ChboxTab05.Checked = False
                ChboxTab06.Checked = False
                ChboxTab07.Checked = False
                ChboxTab08.Checked = False
                ChboxTab09.Checked = False
                ChboxTab10.Checked = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmControlAccesos_MenuCancelar() Handles Me.MenuCancelar
        Try
            SplitContainer2.Panel1Collapsed = False
            SelectMenu(0)
            NuevoToolStripMenuItem1.Enabled = True
            EdicionToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Enabled = False
            ToolStripMenuItem1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewRolFrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRolFrm.Click
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If DataGridViewRolFrm.Rows().Count - 1 = row Then
                Return
            End If
            Call VerificacionSeleccion()
        Catch ex As Exception
            MsgBox("Verificar Seleccion", MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DataGridViewRolFrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewRolFrm.KeyUp
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If DataGridViewRolFrm.Rows().Count - 1 = row Then
                Return
            End If

            If e.KeyData.ToString() = Keys.F2.ToString() Then
                dtoForm.IDCONTROL = 2 'Estado de 1 para la insercion y 0 para la actualizacion
                Dim str As String
                '    Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
                If row >= 0 Then
                    str = DataGridViewRolFrm.Rows(row).DataGridView(1, row).Value().ToString
                    dtoForm.Listar_Datos_Form(str)
                    Dim fdlg As New frmMantenimientoForm
                    fdlg.ShowDialog()
                    If fdlg.DialogResult = Windows.Forms.DialogResult.OK Then
                        ModuUtil.LlenarTreeListViewCtrl(dtoCONTROL_ACCESOS.Listar_Form(), Me.TreeLista, "MODULOS")
                        TreeLista.ExpandAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Segurida Sistema")
        End Try
    End Sub
    Private Sub DataGridViewRolFrm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRolFrm.DoubleClick
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If DataGridViewRolFrm.Rows().Count - 1 = row Then
                Return
            End If
            Call Editar_FORM_ROL()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmControlAccesos_MenuEliminar() Handles Me.MenuEliminar

    End Sub

    Private Sub frmControlAccesos_MenuExEMail() Handles Me.MenuExEMail

    End Sub
    Private Sub frmControlAccesos_MenuExExcel() Handles Me.MenuExExcel

    End Sub
    Private Sub frmControlAccesos_MenuExPDF() Handles Me.MenuExPDF

    End Sub
    Private Sub frmControlAccesos_MenuExWord() Handles Me.MenuExWord

    End Sub
    Public Sub NuevoRegistro()
        Try
            ToolStripMenuItem1.Enabled = False
            chboxTodos.Checked = False
            ChBoxTab.Checked = False

            GroupBoxTAB.Enabled = True
            ChboxTab01.Checked = False
            ChboxTab02.Checked = False
            ChboxTab03.Checked = False
            ChboxTab04.Checked = False
            ChboxTab05.Checked = False
            ChboxTab06.Checked = False
            ChboxTab07.Checked = False
            ChboxTab08.Checked = False
            ChboxTab09.Checked = False
            ChboxTab10.Checked = False

            GroupBoxTOOL.Enabled = True
            chboxAyuda.Checked = False
            chboxCancelar.Checked = False
            chboxEliminar.Checked = False
            chboxExportarExcel.Checked = False
            chboxExportarPDF.Checked = False
            chboxExportarWork.Checked = False
            chboxGrabar.Checked = False
            chboxNuevo.Checked = False
            chboxEditar.Checked = False
            chboxImprimir.Checked = False
            chboxEMAIL.Checked = False
            LimpiarGrid(DataGridViewRoles)
            If TreeLista.SelectedNode().Tag <> 0 Then
                lbFrm.Text = TreeLista.SelectedNode().Text
            Else
                If TreeLista.SelectedNode().Text.Length <= 0 Then
                    MsgBox("Debe Elegir un Iten del Arbol Valido, {No Proceso}", MsgBoxStyle.Critical, "Seguridad Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguidad Sistema")
        End Try
    End Sub
    Private Sub DataGridViewRolFrm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewRolFrm.CellContentClick
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If DataGridViewRolFrm.Rows().Count - 1 = row Then
                Return
            End If
            Call VerificacionSeleccion()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Public Sub VerificacionSeleccion()
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If row >= 0 Then
                EdicionToolStripMenuItem.Enabled = True
            Else
                EdicionToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Revice Datos de Seleccion ...", MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DataGridViewRolFrm_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRolFrm.SelectionChanged

        '        Call VerificacionSeleccion()
    End Sub
    Private Sub frmControlAccesos_MenuNuevo() Handles Me.MenuNuevo
        Try
            Call NuevoRegistro()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmControlAccesos_MenuGrabar() Handles Me.MenuGrabar
        Try
            dtoToolBar.NUEVO = IIf(Me.chboxNuevo.Checked = True, 1, 0)
            dtoToolBar.EDITAR = IIf(Me.chboxEditar.Checked = True, 1, 0)
            dtoToolBar.GRABAR = IIf(Me.chboxGrabar.Checked = True, 1, 0)
            dtoToolBar.CANCELAR = IIf(Me.chboxCancelar.Checked = True, 1, 0)
            dtoToolBar.ELIMINAR = IIf(Me.chboxEliminar.Checked = True, 1, 0)
            dtoToolBar.EXPORTAR_WORK = IIf(Me.chboxExportarWork.Checked = True, 1, 0)
            dtoToolBar.EXPORTAR_EXCEL = IIf(Me.chboxExportarExcel.Checked = True, 1, 0)
            dtoToolBar.EXPORTAR_PDF = IIf(Me.chboxExportarPDF.Checked = True, 1, 0)
            dtoToolBar.IMPRIMIR = IIf(Me.chboxImprimir.Checked = True, 1, 0)
            dtoToolBar.AYUDA = IIf(Me.chboxAyuda.Checked = True, 1, 0)
            dtoToolBar.EMAIL = IIf(Me.chboxEMAIL.Checked = True, 1, 0)

            dtoTabControl.TAB_01 = IIf(Me.ChboxTab01.Checked = True, 1, 0)
            dtoTabControl.TAB_02 = IIf(Me.ChboxTab02.Checked = True, 1, 0)
            dtoTabControl.TAB_03 = IIf(Me.ChboxTab03.Checked = True, 1, 0)
            dtoTabControl.TAB_04 = IIf(Me.ChboxTab04.Checked = True, 1, 0)
            dtoTabControl.TAB_05 = IIf(Me.ChboxTab05.Checked = True, 1, 0)
            dtoTabControl.TAB_06 = IIf(Me.ChboxTab06.Checked = True, 1, 0)
            dtoTabControl.TAB_07 = IIf(Me.ChboxTab07.Checked = True, 1, 0)
            dtoTabControl.TAB_08 = IIf(Me.ChboxTab08.Checked = True, 1, 0)
            dtoTabControl.TAB_09 = IIf(Me.ChboxTab09.Checked = True, 1, 0)
            dtoTabControl.TAB_10 = IIf(Me.ChboxTab10.Checked = True, 1, 0)

            If DataGridViewRoles.Rows().Count > 1 Then
                If dtoTabControl.TAB_01 = 1 And dtoToolBar.GetControl() > 1 Then
                    Dim i As Integer
                    dtoCONTROL_ACCESOS.strRoles = ""
                    If dtoForm.IDCONTROL = 1 Then 'Estado de 1 para la insercion y 0 para la actualizacion
                        For i = 0 To DataGridViewRoles.Rows().Count - 2
                            If i = DataGridViewRoles.Rows().Count - 2 Then
                                dtoCONTROL_ACCESOS.strRoles = dtoCONTROL_ACCESOS.strRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString()
                            Else
                                dtoCONTROL_ACCESOS.strRoles = dtoCONTROL_ACCESOS.strRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString() & ","
                            End If
                        Next i
                    Else
                        Dim row As Integer = Me.DataGridViewRoles.SelectedRows.Item(0).Index
                        dtoCONTROL_ACCESOS.strRoles = DataGridViewRoles.Rows(row).DataGridView(0, row).Value.ToString()
                        'dtoCONTROL_ACCESOS.strRoles = Me.DataGridViewRoles.SelectedRows.Item(0).Index
                    End If
                    If dtoCONTROL_ACCESOS.GRABAR(dtoTabControl, dtoToolBar, dtoForm) = True Then
                        SplitContainer2.Panel1Collapsed = False
                        SelectMenu(0)
                        NuevoToolStripMenuItem1.Enabled = True
                        EdicionToolStripMenuItem.Enabled = True
                        GrabarToolStripMenuItem.Enabled = False
                        ToolStripMenuItem1.Enabled = True
                    End If
                Else
                    MsgBox("Debe Asociar Como minimo un TAB y Mas de Un Control Para su respectivo Registro", MsgBoxStyle.Critical, "Seguridad Sistema")
                End If
            Else
                MsgBox("Debe Asociar Como Minimo un Rol", MsgBoxStyle.Critical, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmControlAccesos_MenuEditar() Handles Me.MenuEditar
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If DataGridViewRolFrm.Rows().Count - 1 = row Then
                Return
            End If

            Call Editar_FORM_ROL()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Public Sub Editar_FORM_ROL()
        Try
            Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
            If row >= 0 Then
                NuevoToolStripMenuItem1.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                GrabarToolStripMenuItem.Enabled = True
                ToolStripMenuItem1.Enabled = False
                TabMante.SelectedIndex = 1
                dtoForm.IDFORMULARIO = DataGridViewRolFrm.Rows(row).DataGridView(0, row).Value
                lbFrm.Text = DataGridViewRolFrm.Rows(row).DataGridView(1, row).Value
                If DataGridViewRolFrm.Rows(row).DataGridView(4, row).Value.ToString.Length > 0 Then
                    dtoForm.IDROL_USUARIO = DataGridViewRolFrm.Rows(row).DataGridView(4, row).Value
                    '---------------------------------------
                    If dtoCONTROL_ACCESOS.SP_LISTAR_FORM_TAB_TOOL(dtoForm.IDFORMULARIO, dtoForm.IDROL_USUARIO) = True Then
                        CargarDataGrid(dtoCONTROL_ACCESOS.rst_Lista_Frm_Roles, DataGridViewRoles, 2)
                        chboxTodos.Checked = False
                        GroupBoxTOOL.Enabled = True
                        ChBoxTab.Checked = False
                        GroupBoxTAB.Enabled = True
                        Me.chboxNuevo.Checked = dtoToolBar.NUEVO
                        Me.chboxEditar.Checked = dtoToolBar.EDITAR
                        Me.chboxGrabar.Checked = dtoToolBar.GRABAR
                        Me.chboxCancelar.Checked = dtoToolBar.CANCELAR
                        Me.chboxEliminar.Checked = dtoToolBar.ELIMINAR
                        Me.chboxExportarWork.Checked = dtoToolBar.EXPORTAR_WORK
                        Me.chboxExportarExcel.Checked = dtoToolBar.EXPORTAR_EXCEL
                        Me.chboxExportarPDF.Checked = dtoToolBar.EXPORTAR_PDF
                        Me.chboxImprimir.Checked = dtoToolBar.IMPRIMIR
                        Me.chboxAyuda.Checked = dtoToolBar.AYUDA
                        Me.chboxEMAIL.Checked = dtoToolBar.EMAIL
                        Me.ChboxTab01.Checked = dtoTabControl.TAB_01
                        Me.ChboxTab02.Checked = dtoTabControl.TAB_02
                        Me.ChboxTab03.Checked = dtoTabControl.TAB_03
                        Me.ChboxTab04.Checked = dtoTabControl.TAB_04
                        Me.ChboxTab05.Checked = dtoTabControl.TAB_05
                        Me.ChboxTab06.Checked = dtoTabControl.TAB_06
                        Me.ChboxTab07.Checked = dtoTabControl.TAB_07
                        Me.ChboxTab08.Checked = dtoTabControl.TAB_08
                        Me.ChboxTab09.Checked = dtoTabControl.TAB_09
                        Me.ChboxTab10.Checked = dtoTabControl.TAB_10
                    End If
                Else
                    Call NuevoRegistro()
                    ModuUtil.LimpiarGrid(DataGridViewRoles)
                End If
            Else
                MsgBox("Debe Elegir un Iten Valido", MsgBoxStyle.Critical, "Seguridad Sistema")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            Dim row As Integer = Me.DataGridViewRoles.SelectedRows.Item(0).Index
            If row >= 0 Then
                dtoCONTROL_ACCESOS.strRoles = DataGridViewRoles.Rows(row).DataGridView(0, row).Value.ToString()
                dtoForm.IDCONTROL = 2
                'dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(0, row).Value.ToString)
                'dtoUSUARIOS.iIDAGENCIAS = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
            Else
                MsgBox("Debe elegir un Iten de la Lista Roles...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewRolFrm_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewRolFrm.MouseDoubleClick
        Dim row As Integer = DataGridViewRolFrm.SelectedRows.Item(0).Index
        If DataGridViewRolFrm.Rows().Count - 1 = row Then
            Return
        End If
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class

