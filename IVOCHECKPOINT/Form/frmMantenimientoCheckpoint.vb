Public Class frmMantenimientoCheckpoint

    'Instancia de Clase de Mantenimiento de checkpoint
    Dim objMantenimientoCheckpoint As New dtoMantenimientoCheckpoint

    'variable para obtener el listado de checkpoint
    Dim dsListaCheckpoint As DataSet
    Dim dsListaCheckpointConfigurado As DataSet

    'variable para obtener el tipo y proceso de checkpoint
    Dim dsTipoProcesoCheckpoint As DataSet
    Dim dsCheckpoint As DataSet

    'variable para obtener el valor de la inserccion de checkpoint
    Dim dsInsertarCheckpoint As DataSet

    Private Sub frmMantenimientoCheckpoint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Visible = True
            AnularToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = False
            ExportarToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = False
            ConsultarToolStripMenuItem.Visible = False
            ReporteToolStripMenuItem.Visible = False
            CierreComisionesToolStripMenuItem.Visible = False

            TCCheckpoint.Controls.RemoveAt(1)

            objMantenimientoCheckpoint.Operacion = 1
            objMantenimientoCheckpoint.Checkpoint = 0

            dsListaCheckpoint = objMantenimientoCheckpoint.fncListarCheckpoint
            If Not IsNothing(dsListaCheckpoint) Then
                dgdCheckpoint.Columns.Clear()
                fncAgregarColumnasCheckpoint()
                dgdCheckpoint.DataSource = dsListaCheckpoint.Tables(0)
            End If

            objMantenimientoCheckpoint.Operacion = 2
            objMantenimientoCheckpoint.Checkpoint = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdCheckpoint").Value

            dsListaCheckpointConfigurado = objMantenimientoCheckpoint.fncListarCheckpointConfigurados
            If Not IsNothing(dsListaCheckpointConfigurado) Then
                dgdCheckpointConfigurado.Columns.Clear()
                fncAgregarColumnasCheckpointConfigurados()
                dgdCheckpointConfigurado.DataSource = dsListaCheckpointConfigurado.Tables(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasCheckpoint()
        Try
            Dim Predecesor As New DataGridViewCheckBoxColumn
            With Predecesor
                .HeaderText = "PREDECESOR"
                .Name = "PREDECESOR"
                .DataPropertyName = "PREDECESOR"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With

            Dim IdCheckPoint As New DataGridViewTextBoxColumn
            With IdCheckPoint
                .HeaderText = "IDCHECKPOINT"
                .Name = "IDCHECKPOINT"
                .DataPropertyName = "IDCHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim AbrevCheckPoint As New DataGridViewTextBoxColumn
            With AbrevCheckPoint
                .HeaderText = "ABREV."
                .Name = "ABREVIATURA"
                .DataPropertyName = "ABREVCHECKPOINT"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreCheckPoint As New DataGridViewTextBoxColumn
            With NombreCheckPoint
                .HeaderText = "NOMBRE"
                .Name = "NOMBRE"
                .DataPropertyName = "NOMBRE_CHECKPOINT"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleCliente As New DataGridViewCheckBoxColumn
            With VisibleCliente
                .HeaderText = "VISIBLE POR CLIENTE"
                .Name = "VISIBLE_CLIENTE"
                .DataPropertyName = "VISIBLE_CLIENTE"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreWeb As New DataGridViewTextBoxColumn
            With NombreWeb
                .HeaderText = "NOMBRE WEB"
                .Name = "NOMBRE_WEB"
                .DataPropertyName = "NOMBRE_WEB"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleUsuario As New DataGridViewCheckBoxColumn
            With VisibleUsuario
                .HeaderText = "VISIBLE POR USUARIO"
                .Name = "VISIBLE_USUARIO"
                .DataPropertyName = "VISIBLE_USUARIO"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 135
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreTitan As New DataGridViewTextBoxColumn
            With NombreTitan
                .HeaderText = "NOMBRE TITAN"
                .Name = "NOMBRE_TITAN"
                .DataPropertyName = "NOMBRE_TITAN"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdProceso As New DataGridViewTextBoxColumn
            With IdProceso
                .HeaderText = "IDPROCESO"
                .Name = "IDPROCESO"
                .DataPropertyName = "IDPROCESO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreProceso As New DataGridViewTextBoxColumn
            With NombreProceso
                .HeaderText = "PROCESO"
                .Name = "PROCESO"
                .DataPropertyName = "NOMBRE_PROCESO"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdTipo_Checkpoint As New DataGridViewTextBoxColumn
            With IdTipo_Checkpoint
                .HeaderText = "IDTIPO_CHECKPOINT"
                .Name = "IDTIPO_CHECKPOINT"
                .DataPropertyName = "IDTIPO_CHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreTipoCheckPoint As New DataGridViewTextBoxColumn
            With NombreTipoCheckPoint
                .HeaderText = "TIPO CHECKPOINT"
                .Name = "NOMBRE_TIPO_CHECKPOINT"
                .DataPropertyName = "TIPO_CHECKPOINT"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            dgdCheckpoint.Columns.AddRange(Predecesor, IdCheckPoint, AbrevCheckPoint, NombreCheckPoint, VisibleUsuario, NombreTitan, VisibleCliente, NombreWeb, IdProceso, NombreProceso, IdTipo_Checkpoint, NombreTipoCheckPoint)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasCheckpointConfigurados()
        Try
            Dim Predecesor As New DataGridViewCheckBoxColumn
            With Predecesor
                .HeaderText = "PREDECESOR"
                .Name = "PREDECESOR"
                .DataPropertyName = "PREDECESOR"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With

            Dim IdCheckPoint As New DataGridViewTextBoxColumn
            With IdCheckPoint
                .HeaderText = "IDCHECKPOINT"
                .Name = "IDCHECKPOINT"
                .DataPropertyName = "IDCHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim AbrevCheckPoint As New DataGridViewTextBoxColumn
            With AbrevCheckPoint
                .HeaderText = "ABREV."
                .Name = "ABREVIATURA"
                .DataPropertyName = "ABREVCHECKPOINT"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreCheckPoint As New DataGridViewTextBoxColumn
            With NombreCheckPoint
                .HeaderText = "NOMBRE"
                .Name = "NOMBRE"
                .DataPropertyName = "NOMBRE_CHECKPOINT"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleCliente As New DataGridViewCheckBoxColumn
            With VisibleCliente
                .HeaderText = "VISIBLE POR CLIENTE"
                .Name = "VISIBLE_CLIENTE"
                .DataPropertyName = "VISIBLE_CLIENTE"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreWeb As New DataGridViewTextBoxColumn
            With NombreWeb
                .HeaderText = "NOMBRE WEB"
                .Name = "NOMBRE_WEB"
                .DataPropertyName = "NOMBRE_WEB"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleUsuario As New DataGridViewCheckBoxColumn
            With VisibleUsuario
                .HeaderText = "VISIBLE POR USUARIO"
                .Name = "VISIBLE_USUARIO"
                .DataPropertyName = "VISIBLE_USUARIO"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 135
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreTitan As New DataGridViewTextBoxColumn
            With NombreTitan
                .HeaderText = "NOMBRE TITAN"
                .Name = "NOMBRE_TITAN"
                .DataPropertyName = "NOMBRE_TITAN"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdProceso As New DataGridViewTextBoxColumn
            With IdProceso
                .HeaderText = "IDPROCESO"
                .Name = "IDPROCESO"
                .DataPropertyName = "IDPROCESO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreProceso As New DataGridViewTextBoxColumn
            With NombreProceso
                .HeaderText = "PROCESO"
                .Name = "PROCESO"
                .DataPropertyName = "NOMBRE_PROCESO"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdTipo_Checkpoint As New DataGridViewTextBoxColumn
            With IdTipo_Checkpoint
                .HeaderText = "IDTIPO_CHECKPOINT"
                .Name = "IDTIPO_CHECKPOINT"
                .DataPropertyName = "IDTIPO_CHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreTipoCheckPoint As New DataGridViewTextBoxColumn
            With NombreTipoCheckPoint
                .HeaderText = "TIPO CHECKPOINT"
                .Name = "NOMBRE_TIPO_CHECKPOINT"
                .DataPropertyName = "TIPO_CHECKPOINT"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            dgdCheckpointConfigurado.Columns.AddRange(Predecesor, IdCheckPoint, AbrevCheckPoint, NombreCheckPoint, VisibleUsuario, NombreTitan, VisibleCliente, NombreWeb, IdProceso, NombreProceso, IdTipo_Checkpoint, NombreTipoCheckPoint)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '-----------------------------------------------------------------------------------------
    '--------------- Pestaña de Listado y Consulta de  de Checkpoint  ------------------------
    '-----------------------------------------------------------------------------------------
    Private Sub dgdCheckpoint_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCheckpoint.CellClick
        Try
            objMantenimientoCheckpoint.Operacion = 2
            objMantenimientoCheckpoint.Checkpoint = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdCheckpoint").Value

            dsListaCheckpointConfigurado = objMantenimientoCheckpoint.fncListarCheckpointConfigurados
            If Not IsNothing(dsListaCheckpointConfigurado) Then
                dgdCheckpointConfigurado.Columns.Clear()
                fncAgregarColumnasCheckpointConfigurados()
                dgdCheckpointConfigurado.DataSource = dsListaCheckpointConfigurado.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = True

            TCCheckpoint.Controls.RemoveAt(0)
            TCCheckpoint.TabPages.Add(TPMantenimientoCheckpoint)

            txtAbreviatura.Text = ""
            txtNombre.Text = ""

            chkVisibleCliente.Checked = False
            chkVisibleUsuario.Checked = False
            txtDescripcionWeb.Enabled = False
            txtDescripcionUsuario.Enabled = False
            txtDescripcionWeb.Text = ""
            txtDescripcionUsuario.Text = ""

            dsTipoProcesoCheckpoint = objMantenimientoCheckpoint.fncListarTipoCheckpoint

            cboTipo.DataSource = dsTipoProcesoCheckpoint.Tables(0)
            cboTipo.DisplayMember = "Nombre_Checkpoint"
            cboTipo.ValueMember = "IdTipo_Checkpoint"

            cboProceso.DataSource = dsTipoProcesoCheckpoint.Tables(1)
            cboProceso.DisplayMember = "Nombre_Proceso"
            cboProceso.ValueMember = "Idproceso"

            objMantenimientoCheckpoint.Operacion = 1
            objMantenimientoCheckpoint.Checkpoint = 0

            dsCheckpoint = objMantenimientoCheckpoint.fncListarCheckpoint
            If Not IsNothing(dsCheckpoint) Then
                dgdPrecedencia.Columns.Clear()
                fncAgregarColumnasPredecesor()
                dgdPrecedencia.DataSource = dsCheckpoint.Tables(0)
            End If

            txtAbreviatura.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        Try
            TCCheckpoint.Controls.RemoveAt(0)
            TCCheckpoint.TabPages.Add(TPMantenimientoCheckpoint)
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = True

            dsTipoProcesoCheckpoint = objMantenimientoCheckpoint.fncListarTipoCheckpoint

            cboTipo.DataSource = dsTipoProcesoCheckpoint.Tables(0)
            cboTipo.DisplayMember = "Nombre_Checkpoint"
            cboTipo.ValueMember = "IdTipo_Checkpoint"
            cboTipo.SelectedValue = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdTipo_Checkpoint").Value

            cboProceso.DataSource = dsTipoProcesoCheckpoint.Tables(1)
            cboProceso.DisplayMember = "Nombre_Proceso"
            cboProceso.ValueMember = "Idproceso"
            cboProceso.SelectedValue = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdProceso").Value

            txtAbreviatura.Text = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Abreviatura").Value.ToString
            txtNombre.Text = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Nombre").Value.ToString

            If dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Visible_Cliente").Value = 1 Then
                chkVisibleCliente.Checked = True
                txtDescripcionWeb.Enabled = True
                txtDescripcionWeb.Text = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Nombre_Web").Value.ToString
            Else
                chkVisibleCliente.Checked = False
                txtDescripcionWeb.Enabled = False
                txtDescripcionWeb.Text = ""
            End If

            If dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Visible_Usuario").Value = 1 Then
                chkVisibleUsuario.Checked = True
                txtDescripcionUsuario.Enabled = True
                txtDescripcionUsuario.Text = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("Nombre_Titan").Value.ToString
            Else
                chkVisibleUsuario.Checked = False
                txtDescripcionUsuario.Enabled = False
                txtDescripcionUsuario.Text = ""
            End If

            objMantenimientoCheckpoint.Operacion = 2
            objMantenimientoCheckpoint.Checkpoint = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdCheckpoint").Value

            dsCheckpoint = objMantenimientoCheckpoint.fncListarCheckpoint
            If Not IsNothing(dsCheckpoint) Then
                dgdPrecedencia.Columns.Clear()
                fncAgregarColumnasPredecesor()
                dgdPrecedencia.DataSource = dsCheckpoint.Tables(0)
            End If

            txtAbreviatura.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasPredecesor()
        Try
            Dim Predecesor As New DataGridViewCheckBoxColumn
            With Predecesor
                .HeaderText = "PREDECESOR"
                .Name = "PREDECESOR"
                .DataPropertyName = "PREDECESOR"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim IdCheckPoint As New DataGridViewTextBoxColumn
            With IdCheckPoint
                .HeaderText = ""
                .Name = ""
                .DataPropertyName = "IDCHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim AbrevCheckPoint As New DataGridViewTextBoxColumn
            With AbrevCheckPoint
                .HeaderText = "ABREV."
                .Name = "ABREVIATURA"
                .DataPropertyName = "ABREVCHECKPOINT"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreCheckPoint As New DataGridViewTextBoxColumn
            With NombreCheckPoint
                .HeaderText = "NOMBRE"
                .Name = "NOMBRE"
                .DataPropertyName = "NOMBRE_CHECKPOINT"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleCliente As New DataGridViewCheckBoxColumn
            With VisibleCliente
                .HeaderText = "VISIBLE POR CLIENTE"
                .Name = "VISIBLE_CLIENTE"
                .DataPropertyName = "VISIBLE_CLIENTE"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreWeb As New DataGridViewTextBoxColumn
            With NombreWeb
                .HeaderText = "NOMBRE WEB"
                .Name = "NOMBRE_WEB"
                .DataPropertyName = "NOMBRE_WEB"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim VisibleUsuario As New DataGridViewCheckBoxColumn
            With VisibleUsuario
                .HeaderText = "VISIBLE POR USUARIO"
                .Name = "VISIBLE_USUARIO"
                .DataPropertyName = "VISIBLE_USUARIO"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 135
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NombreTitan As New DataGridViewTextBoxColumn
            With NombreTitan
                .HeaderText = "NOMBRE TITAN"
                .Name = "NOMBRE_TITAN"
                .DataPropertyName = "NOMBRE_TITAN"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdProceso As New DataGridViewTextBoxColumn
            With IdProceso
                .HeaderText = ""
                .Name = ""
                .DataPropertyName = "IDPROCESO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreProceso As New DataGridViewTextBoxColumn
            With NombreProceso
                .HeaderText = "PROCESO"
                .Name = "PROCESO"
                .DataPropertyName = "NOMBRE_PROCESO"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdTipo_Checkpoint As New DataGridViewTextBoxColumn
            With IdTipo_Checkpoint
                .HeaderText = ""
                .Name = ""
                .DataPropertyName = "IDTIPO_CHECKPOINT"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreTipoCheckPoint As New DataGridViewTextBoxColumn
            With NombreTipoCheckPoint
                .HeaderText = "TIPO CHECKPOINT"
                .Name = "NOMBRE_TIPO_CHECKPOINT"
                .DataPropertyName = "TIPO_CHECKPOINT"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            dgdPrecedencia.Columns.AddRange(Predecesor, IdCheckPoint, AbrevCheckPoint, NombreCheckPoint, VisibleUsuario, NombreTitan, VisibleCliente, NombreWeb, IdProceso, NombreProceso, IdTipo_Checkpoint, NombreTipoCheckPoint)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '---------------------------------------------------------------------------------------
    '--------------- Pestaña de Generación y Edición de Checkpoint  ------------------------
    '---------------------------------------------------------------------------------------
    Private Sub chkVisibleCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVisibleCliente.CheckedChanged
        Try
            If chkVisibleCliente.Checked = False Then
                txtDescripcionWeb.Enabled = False
                txtDescripcionWeb.Text = ""
            Else
                txtDescripcionWeb.Enabled = True
                txtDescripcionWeb.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkVisibleUsuario_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVisibleUsuario.CheckedChanged
        Try
            If chkVisibleUsuario.Checked = False Then
                txtDescripcionUsuario.Enabled = False
                txtDescripcionUsuario.Text = ""
            Else
                txtDescripcionUsuario.Enabled = True
                txtDescripcionUsuario.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgdPrecedencia_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrecedencia.CellClick
        Try
            If e.RowIndex < 0 Or Not e.ColumnIndex = 0 Then Exit Sub

            If dgdPrecedencia.Rows(dgdPrecedencia.CurrentRow.Index).Cells("PREDECESOR").Value = False Then
                dgdPrecedencia.Rows(e.RowIndex).Cells("PREDECESOR").Value = True
                dsCheckpoint.Tables(0).Rows(dgdPrecedencia.CurrentRow.Index).Item("PREDECESOR") = 1
            Else
                dgdPrecedencia.Rows(e.RowIndex).Cells("PREDECESOR").Value = False
                dsCheckpoint.Tables(0).Rows(dgdPrecedencia.CurrentRow.Index).Item("PREDECESOR") = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        Try
            If txtAbreviatura.Text = "" Then
                MessageBox.Show("Ingrese la abreviatura del checkpoint", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtAbreviatura.Focus()
                Return
            End If

            If txtNombre.Text = "" Then
                MessageBox.Show("Ingrese el nombre del checkpoint", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtNombre.Focus()
                Return
            End If

            If chkVisibleCliente.Checked = True And txtDescripcionWeb.Text = "" Then
                MessageBox.Show("Ingrese la descripción del checkpoint que aparecerá en la web", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtDescripcionWeb.Focus()
                Return
            End If

            If chkVisibleUsuario.Checked = True And txtDescripcionUsuario.Text = "" Then
                MessageBox.Show("Ingrese la descripción del checkpoint que aparecerá en el sistema titán", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtDescripcionUsuario.Focus()
                Return
            End If

            objMantenimientoCheckpoint.TipoCheckpoint = cboTipo.SelectedValue
            objMantenimientoCheckpoint.ProcesoCheckpoint = cboProceso.SelectedValue
            objMantenimientoCheckpoint.AbreviaturaCheckpoint = txtAbreviatura.Text.Trim
            objMantenimientoCheckpoint.NombreCheckpoint = txtNombre.Text.Trim
            objMantenimientoCheckpoint.VisibleCliente = Convert.ToInt32(chkVisibleCliente.Checked)
            objMantenimientoCheckpoint.VisibleUsuario = Convert.ToInt32(chkVisibleUsuario.Checked)
            objMantenimientoCheckpoint.DescripcionWeb = txtDescripcionWeb.Text.Trim
            objMantenimientoCheckpoint.DescripcionUsuario = txtDescripcionUsuario.Text.Trim

            If objMantenimientoCheckpoint.Operacion = 1 Then
                dsInsertarCheckpoint = objMantenimientoCheckpoint.fncInsertarCheckpoint
                If Convert.ToInt32(dsInsertarCheckpoint.Tables(0).Rows(0).Item(0).ToString) = 666 Then

                    objMantenimientoCheckpoint.Checkpoint = Convert.ToInt32(dsInsertarCheckpoint.Tables(0).Rows(0).Item(2).ToString())

                    If dsCheckpoint.Tables(0).Rows.Count > 0 Then
                        For index As Integer = 0 To dsCheckpoint.Tables(0).Rows.Count - 1
                            If Convert.ToInt32(dsCheckpoint.Tables(0).Rows(index).Item("PREDECESOR").ToString) = 1 Then
                                objMantenimientoCheckpoint.CheckpointPredecesor = Convert.ToInt32(dsCheckpoint.Tables(0).Rows(index).Item("IDCHECKPOINT").ToString)
                                objMantenimientoCheckpoint.fncInsertarCheckpointPredecesor()
                            End If
                        Next
                    End If

                    dsCheckpoint = objMantenimientoCheckpoint.fncListarCheckpoint
                    If Not IsNothing(dsCheckpoint) Then
                        dgdPrecedencia.Columns.Clear()
                        fncAgregarColumnasPredecesor()
                        dgdPrecedencia.DataSource = dsCheckpoint.Tables(0)
                    End If

                    MessageBox.Show(dsInsertarCheckpoint.Tables(0).Rows(0).Item(1).ToString, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtAbreviatura.Text = ""
                    txtNombre.Text = ""

                    chkVisibleCliente.Checked = False
                    chkVisibleUsuario.Checked = False
                    txtDescripcionWeb.Enabled = False
                    txtDescripcionUsuario.Enabled = False

                    txtDescripcionWeb.Text = ""
                    txtDescripcionUsuario.Text = ""
                    objMantenimientoCheckpoint.Checkpoint = 0
                    objMantenimientoCheckpoint.TipoCheckpoint = 0
                    objMantenimientoCheckpoint.ProcesoCheckpoint = 0
                    objMantenimientoCheckpoint.AbreviaturaCheckpoint = ""
                    objMantenimientoCheckpoint.NombreCheckpoint = ""
                    objMantenimientoCheckpoint.VisibleCliente = 0
                    objMantenimientoCheckpoint.VisibleUsuario = 0
                    objMantenimientoCheckpoint.DescripcionWeb = ""
                    objMantenimientoCheckpoint.DescripcionUsuario = ""

                    txtAbreviatura.Focus()
                Else
                    MessageBox.Show(dsInsertarCheckpoint.Tables(0).Rows(0).Item(1).ToString, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    txtAbreviatura.Focus()
                End If
            ElseIf objMantenimientoCheckpoint.Operacion = 2 Then
                dsInsertarCheckpoint = objMantenimientoCheckpoint.fncInsertarCheckpoint
                If Convert.ToInt32(dsInsertarCheckpoint.Tables(0).Rows(0).Item(0).ToString) = 666 Then

                    If dsCheckpoint.Tables(0).Rows.Count > 0 Then
                        For index As Integer = 0 To dsCheckpoint.Tables(0).Rows.Count - 1
                            objMantenimientoCheckpoint.CheckpointPredecesor = Convert.ToInt32(dsCheckpoint.Tables(0).Rows(index).Item("IDCHECKPOINT").ToString)
                            objMantenimientoCheckpoint.Marca = Convert.ToInt32(dsCheckpoint.Tables(0).Rows(index).Item("PREDECESOR").ToString)
                            objMantenimientoCheckpoint.fncInsertarCheckpointPredecesor()
                        Next
                    End If

                    MessageBox.Show(dsInsertarCheckpoint.Tables(0).Rows(0).Item(1).ToString, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    txtAbreviatura.Text = ""
                    txtNombre.Text = ""

                    chkVisibleCliente.Checked = False
                    chkVisibleUsuario.Checked = False
                    txtDescripcionWeb.Enabled = False
                    txtDescripcionUsuario.Enabled = False

                    txtDescripcionWeb.Text = ""
                    txtDescripcionUsuario.Text = ""
                    objMantenimientoCheckpoint.Checkpoint = 0
                    objMantenimientoCheckpoint.TipoCheckpoint = 0
                    objMantenimientoCheckpoint.ProcesoCheckpoint = 0
                    objMantenimientoCheckpoint.AbreviaturaCheckpoint = ""
                    objMantenimientoCheckpoint.NombreCheckpoint = ""
                    objMantenimientoCheckpoint.VisibleCliente = 0
                    objMantenimientoCheckpoint.VisibleUsuario = 0
                    objMantenimientoCheckpoint.DescripcionWeb = ""
                    objMantenimientoCheckpoint.DescripcionUsuario = ""

                    CancelarToolStripmenuItem_Click(sender, e)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CancelarToolStripmenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelarToolStripmenuItem.Click
        Try
            TCCheckpoint.Controls.RemoveAt(0)
            TCCheckpoint.TabPages.Add(TPConsultaCheckpoint)
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Visible = True
            AnularToolStripMenuItem.Visible = True
            GrabarToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False

            objMantenimientoCheckpoint.Operacion = 1
            dsListaCheckpoint = objMantenimientoCheckpoint.fncListarCheckpoint
            If Not IsNothing(dsListaCheckpoint) Then
                dgdCheckpoint.Columns.Clear()
                fncAgregarColumnasCheckpoint()
                dgdCheckpoint.DataSource = dsListaCheckpoint.Tables(0)
            End If

            objMantenimientoCheckpoint.Operacion = 2
            objMantenimientoCheckpoint.Checkpoint = dgdCheckpoint.Rows(dgdCheckpoint.CurrentRow.Index).Cells("IdCheckpoint").Value

            dsListaCheckpointConfigurado = objMantenimientoCheckpoint.fncListarCheckpointConfigurados
            If Not IsNothing(dsListaCheckpointConfigurado) Then
                dgdCheckpointConfigurado.Columns.Clear()
                fncAgregarColumnasCheckpointConfigurados()
                dgdCheckpointConfigurado.DataSource = dsListaCheckpointConfigurado.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class