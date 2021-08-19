Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmCiudadTipoGasto
    Dim intOperacion As Operacion
    Dim cboCiudad As Object

    Sub FormatearDGVCiudad()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_pago As New DataGridViewTextBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Activacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idciudad As New DataGridViewTextBoxColumn
            With col_idciudad
                .Name = "idciudad" : .DataPropertyName = "idciudad" : .DisplayIndex = x : .Visible = False : .HeaderText = "Ciudad"
            End With
            x += +1
            Dim col_idtipo_gasto As New DataGridViewTextBoxColumn
            With col_idtipo_gasto
                .Name = "idtipo_gasto" : .DataPropertyName = "idtipo_gasto" : .DisplayIndex = x : .Visible = False : .HeaderText = "Tipo Pago"
            End With

            .Columns.AddRange(col_id, col_ciudad, col_tipo_pago, col_fecha_inicio, col_idciudad, col_idtipo_gasto)
        End With
    End Sub

    Private Sub frmOficinaGasto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
    End Sub

    Sub Inicio()
        FormatearDGVCiudad()

        Dim obj As New Cls_Gasto_LN
        Dim dt As DataTable = obj.ListarCiudadTipoPago
        Me.dgv.DataSource = dt
    End Sub

    Sub ActivarDesactivar(tab As Integer)
        If tab = 0 Then
            Me.tsbGrabar.Enabled = False
            If Me.dgv.Rows.Count = 0 Then
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            End If
        Else
            Me.tsbGrabar.Enabled = True
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Sub Limpiar()
        Me.lblCiudad.Text = ""
        Me.lblFechaActivacion.Text = ""

        Me.dtpFechaActivacion.Value = FechaServidor()
        Me.cboTipoPago.SelectedValue = 0
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Editar()
        Me.tab.SelectedIndex = 1
        Me.dtpFechaActivacion.Focus()
        intOperacion = Operacion.Modificar
    End Sub

    Sub Editar()
        Limpiar()

        Dim obj As New Cls_Gasto_LN
        With Me.cboTipoPago
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            '.DataSource = obj.ListarTipoPago(2, IIf(IsDBNull(dgv.CurrentRow.Cells("idtipo_gasto").Value), 0, dgv.CurrentRow.Cells("idtipo_gasto").Value))
            .DataSource = obj.ListarTipoPago(2, 0)
            .SelectedValue = 0
        End With
        With Me.dgv.CurrentRow
            Me.lblCiudad.Text = .Cells("ciudad").Value
            Me.lblTipoPago.Text = .Cells("tipo_pago").Value
            Me.cboTipoPago.SelectedValue = IIf(IsDBNull(.Cells("idtipo_gasto").Value), 0, .Cells("idtipo_gasto").Value)

            If IsDBNull(.Cells("fecha_inicio").Value) Then
                Me.lblFechaActivacion.Text = ""
                Me.dtpFechaActivacion.Value = FechaServidor()
            Else
                Me.lblFechaActivacion.Text = .Cells("fecha_inicio").Value
                Me.dtpFechaActivacion.Value = DateAdd(DateInterval.Day, 1, CDate(FechaServidor()))
            End If
        End With
    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tab_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tab.SelectedIndexChanged
        If tab.SelectedIndex = 1 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
        ActivarDesactivar(Me.tab.SelectedIndex)
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Try
            If Me.cboTipoPago.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Pago", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoPago.Focus()
                Me.cboTipoPago.DroppedDown = True
                Return
            End If

            If Me.lblTipoPago.Text.Trim.Length > 0 Then
                If Me.cboTipoPago.SelectedValue = Me.dgv.CurrentRow.Cells("idtipo_gasto").Value Then
                    MessageBox.Show("Seleccione otro Tipo de Pago", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboTipoPago.Focus()
                    Me.cboTipoPago.DroppedDown = True
                    Return
                End If
            End If

            Cursor = Cursors.WaitCursor
            Grabar()

            Me.Inicio()
            Me.tab.SelectedIndex = 0

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Anular()
    End Sub

    Sub Anular()
        Try
            Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de anular la Asociación?", "Asociar Tipo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Dim obj As New Cls_Gasto_LN
                Dim objEN As New Cls_Gasto_EN
                objEN.ID = Me.dgv.CurrentRow.Cells("id").Value
                obj.AnularCiudadTipoPago(objEN)
                Me.Inicio()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub Grabar()
        Try
            Dim obj As New Cls_Gasto_LN
            Dim objEN As New Cls_Gasto_EN

            objEN.ID = IIf(IsDBNull(Me.dgv.CurrentRow.Cells("id").Value), 0, Me.dgv.CurrentRow.Cells("id").Value)

            objEN.Ciudad = Me.dgv.CurrentRow.Cells("idciudad").Value
            objEN.TipoGasto = Me.cboTipoPago.SelectedValue
            objEN.FechaInicio = Me.dtpFechaActivacion.Value.ToShortDateString
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            obj.GrabarCiudadTipoPago(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub dgv_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        If IsReference(dgv.Rows(e.RowIndex).Cells("idtipo_gasto").Value) Then
            Me.tsbAnular.Enabled = False
            Return
        End If
        If dgv.Rows.Count > 0 Then
            If dgv.Rows(e.RowIndex).Cells("idtipo_gasto").Value = 0 Then
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbAnular.Enabled = True
            End If
        End If
    End Sub
End Class