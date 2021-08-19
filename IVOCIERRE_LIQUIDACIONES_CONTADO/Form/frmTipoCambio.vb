Imports INTEGRACION_LN
Public Class frmTipoCambio
    Dim strFechaServidor As String
    Dim intOperacion As Operacion
    Dim blnEscribir As Boolean

    Sub FormateardgvLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
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
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_monto, col_usuario)
        End With
    End Sub

    Private Sub frmTipoCambio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FormateardgvLista()
            strFechaServidor = FechaServidor()
            RemoveHandler dtpFin.ValueChanged, AddressOf dtpFin_ValueChanged
            Me.dtpFin.Value = strFechaServidor
            AddHandler dtpFin.ValueChanged, AddressOf dtpFin_ValueChanged
            Me.dtpInicio.Value = strFechaServidor

            If Not Acceso.SiRol(G_Rol, Me, 1, 1) Then
                blnEscribir = False
            Else
                blnEscribir = True
            End If

            If Not blnEscribir Then
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbAnular.Enabled = False
                Me.txtMonto.Enabled = False
            End If

            tabTipoCambio_SelectedIndexChanged(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        tabTipoCambio.SelectedTab = tabTipoCambio.TabPages("tabMantenimiento")
        intOperacion = Operacion.Nuevo
        Me.dtpFecha.Value = FechaServidor()
        Me.txtMonto.Text = ""
        Me.txtMonto.Focus()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Try
            Dim strFecha As String
            If Val(Me.txtMonto.Text) = 0 Then
                MessageBox.Show("Ingrese monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMonto.Focus()
                Return
            End If
            Grabar()

            strFecha = FechaServidor()
            RemoveHandler dtpFin.ValueChanged, AddressOf dtpFin_ValueChanged
            Me.dtpFin.Value = strFecha
            AddHandler dtpFin.ValueChanged, AddressOf dtpFin_ValueChanged
            Me.dtpInicio.Value = strFecha
            Me.tabTipoCambio.SelectedTab = tabTipoCambio.TabPages("tabLista")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim intId As Integer
            Dim dblMonto As Double
            Dim strFecha As String

            If intOperacion = Operacion.Nuevo Then
                intId = 0
            Else
                intId = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            strFecha = Me.dtpFecha.Value.ToShortDateString
            dblMonto = CType(Me.txtMonto.Text, Double)

            obj.GrabarTipoCambio(intId, strFecha, dblMonto, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub txtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.Enter
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.tsbGrabar.Enabled Then
                tsbGrabar_Click(Nothing, Nothing)
            End If
        Else
            If Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        If Val(Me.txtMonto.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtMonto.Text)
            Me.txtMonto.Text = Format(dblMonto, "0.00")
        Else
            Me.txtMonto.Text = "0.00"
        End If
    End Sub

    Sub Listar()
        Dim obj As New Cls_LiquidacionValor_LN
        Dim strInicio As String, strFin As String

        strInicio = Me.dtpInicio.Value.ToShortDateString
        strFin = Me.dtpFin.Value.ToShortDateString

        Dim dt As DataTable = obj.ListarTipoCambio(strInicio, strFin)
        Me.dgvLista.DataSource = dt

        If blnEscribir Then
            Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
            Me.tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        Try
            Listar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
        Try
            Listar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabTipoCambio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTipoCambio.SelectedIndexChanged
        If Not blnEscribir Then Return
        If tabTipoCambio.SelectedTab Is tabTipoCambio.TabPages("tabLista") Then
            Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
        Else
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = True
            Me.tsbAnular.Enabled = False
            tsbNuevo_Click(Nothing, Nothing)
        End If
    End Sub

    Sub Anular()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim intId As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            obj.AnularTipoCambio(intId, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular el tipo de cambio con fecha " & Me.dgvLista.CurrentRow.Cells("fecha").Value & "?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular()
                Listar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Not blnEscribir Then Return
        If Me.tsbEditar.Enabled Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        If Not blnEscribir Then Return
        Dim strFecha As String, strFecha2 As String
        strFecha = Me.dgvLista.Rows(e.RowIndex).Cells("fecha").Value
        strFecha2 = CType(strFechaServidor, Date).ToShortDateString

        If Me.dgvLista.Rows.Count > 0 AndAlso CDate(strFecha2) = CDate(strFecha) Then
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = True
        Else
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        tabTipoCambio.SelectedTab = tabTipoCambio.TabPages("tabMantenimiento")
        intOperacion = Operacion.Modificar
        Me.dtpFecha.Value = Me.dgvLista.CurrentRow.Cells("fecha").Value
        Me.txtMonto.Text = Me.dgvLista.CurrentRow.Cells("monto").Value
        Me.txtMonto.Focus()
        Me.txtMonto.SelectAll()
    End Sub
End Class